using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using observerpattern.Application;
using observerpattern.Domain;

namespace observer_pattern.UnitTests
{
    [TestClass]
    public class NotificationServiceShould
    {
        private static DeviceConfiguration _deviceConfiguration;
        private static Mock<IServiceBroker> _serviceBrokerMock;
        private static Mock<INotificationRepository> _notificationRepositoryMock;

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            _deviceConfiguration = new DeviceConfiguration();
            _serviceBrokerMock = new Mock<IServiceBroker>();
            _notificationRepositoryMock = new Mock<INotificationRepository>();
        }

        [TestMethod]
        public void call_repository_save_method_once_when_one_device_service_is_used()
        {
            // ARRANGE
            AndroidService androidService = new AndroidService(_deviceConfiguration, _serviceBrokerMock.Object);
            androidService.Attach(_notificationRepositoryMock.Object);
            Notification notification = new Notification();

            // ACT
            androidService.OnNotificationSucceed(notification);

            // ASSERT
            _notificationRepositoryMock.Verify(n => n.Save(notification), Times.Once);
        }

        [TestMethod]
        public void call_repository_save_method_twice_when_two_device_services_are_used()
        {
            // ARRANGE
            AndroidService androidService = new AndroidService(_deviceConfiguration, _serviceBrokerMock.Object);
            IosService iosService = new IosService(_deviceConfiguration, _serviceBrokerMock.Object);
            androidService.Attach(_notificationRepositoryMock.Object);
            iosService.Attach(_notificationRepositoryMock.Object);
            Notification notification = new Notification();

            // ACT
            androidService.OnNotificationSucceed(notification);
            iosService.OnNotificationSucceed(notification);

            // ASSERT
            _notificationRepositoryMock.Verify(n => n.Save(notification), Times.Exactly(2));
        }

        [TestMethod]
        public void call_service_broker_send_method_once_when_one_device_service_is_used()
        {
            // ARRANGE
            AndroidService androidService = new AndroidService(_deviceConfiguration, _serviceBrokerMock.Object);
            androidService.Attach(_notificationRepositoryMock.Object);

            List<Subject> deviceServices = new List<Subject>
            {
                androidService
            };

            NotificationsService notificationsService = new NotificationsService(deviceServices, _notificationRepositoryMock.Object);

            List<Notification> notifications = new List<Notification> 
            {
                new Notification() 
            };

            // ACT
            notificationsService.Process(notifications);

            // ASSERT
            _serviceBrokerMock.Verify(n => n.Queue(notifications[0]), Times.Once);
        }

        [TestMethod]
        public void call_service_broker_send_method_twice_when_two_device_services_are_used()
        {
            // ARRANGE
            AndroidService androidService = new AndroidService(_deviceConfiguration, _serviceBrokerMock.Object);
            IosService iosService = new IosService(_deviceConfiguration, _serviceBrokerMock.Object);
            androidService.Attach(_notificationRepositoryMock.Object);
            iosService.Attach(_notificationRepositoryMock.Object);

            List<Subject> deviceServices = new List<Subject>
            {
                androidService,
                iosService
            };

            NotificationsService notificationsService = new NotificationsService(deviceServices, _notificationRepositoryMock.Object);

            List<Notification> notifications = new List<Notification>
            {
                new Notification()
            };

            // ACT
            notificationsService.Process(notifications);

            // ASSERT
            _serviceBrokerMock.Verify(n => n.Queue(notifications[0]), Times.Exactly(2));
        }

    }
}
