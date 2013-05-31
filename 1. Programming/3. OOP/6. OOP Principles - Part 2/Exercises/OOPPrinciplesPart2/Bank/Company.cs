namespace Bank
{
    class Company : Customer
    {
        private string eik;

        public string EIK
        {
            get { return this.eik; }
            set { this.eik = value; }
        }

        public Company(string name, string EIK)
        {
            this.name = name;
            this.eik = EIK;
        }
    }
}
