namespace observerpattern.Domain
{
    public class Table : Subject
    {
        public int Number { get; set; }
        public bool Vip { get; set; }

        private int _status { get; set; }

        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;

                if (value == 0)
                {
                    Event e = new Event(tableNumber: Number, isVip: Vip);
                    NotifyAll(e);
                }
            }
        }

        public Table(int tableNumber, bool isVip)
            : base()
        {
            Number = tableNumber;
            Vip = isVip;
        }
    }
}
