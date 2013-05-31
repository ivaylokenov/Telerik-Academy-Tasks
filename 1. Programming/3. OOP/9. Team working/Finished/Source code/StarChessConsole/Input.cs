namespace StarChessConsole
{
    class Input : Interfaces.IUserInput
    {
        private string currentInput;

        public string CurrentInput
        {
            get { return this.currentInput; }
            set { this.currentInput = value; }
        }

        public Input(string input)
        {
            this.currentInput = input;
        }

        public void Rocade()
        {
            throw new System.NotImplementedException();
        }

        public string GetFieldCoordinates()
        {
            string[] splitedInput = this.currentInput.Split('-');

            string lastPosition = splitedInput[0];
            string nextPosition = splitedInput[1];

            string coordinates = string.Empty;

            switch (lastPosition[0])
            {
                case 'A': coordinates += '0'; break;
                case 'B': coordinates += '1'; break;
                case 'C': coordinates += '2'; break;
                case 'D': coordinates += '3'; break;
                case 'E': coordinates += '4'; break;
                case 'F': coordinates += '5'; break;
                case 'G': coordinates += '6'; break;
                case 'H': coordinates += '7'; break;
            }

            coordinates += '-';

            switch (lastPosition[1])
            {
                case '8': coordinates += '0'; break;
                case '7': coordinates += '1'; break;
                case '6': coordinates += '2'; break;
                case '5': coordinates += '3'; break;
                case '4': coordinates += '4'; break;
                case '3': coordinates += '5'; break;
                case '2': coordinates += '6'; break;
                case '1': coordinates += '7'; break;
            }

            coordinates += '-';

            switch (nextPosition[0])
            {
                case 'A': coordinates += '0'; break;
                case 'B': coordinates += '1'; break;
                case 'C': coordinates += '2'; break;
                case 'D': coordinates += '3'; break;
                case 'E': coordinates += '4'; break;
                case 'F': coordinates += '5'; break;
                case 'G': coordinates += '6'; break;
                case 'H': coordinates += '7'; break;
            }

            coordinates += '-';

            switch (nextPosition[1])
            {
                case '8': coordinates += '0'; break;
                case '7': coordinates += '1'; break;
                case '6': coordinates += '2'; break;
                case '5': coordinates += '3'; break;
                case '4': coordinates += '4'; break;
                case '3': coordinates += '5'; break;
                case '2': coordinates += '6'; break;
                case '1': coordinates += '7'; break;
            }

            return coordinates;
        }


        public bool ValidateInput()
        {
            //convert to uppercase
            this.CurrentInput = this.currentInput.ToUpper();

            //bool hasRocade = false;
            
            //check rokade
            /*
            if (this.CurrentInput == 6 && this.currentInput[0] == 'R')
            {
                hasRocade = true;
            }
            */

            if (this.CurrentInput.Length == 5
                && this.currentInput[0] >= 65 && this.currentInput[0] <= 72 //first is letter
                && this.currentInput[1] >= 49 && this.currentInput[1] <= 56 //second is number
                && this.currentInput[2] == '-' //third symbol is dash
                && this.currentInput[3] >= 65 && this.currentInput[0] <= 72 //first is letter
                && this.currentInput[4] >= 49 && this.currentInput[1] <= 56) //second is number
            {
                return true;
            }

            throw new InvalidInputException("wrong input!");
        }
    }
}
