namespace Game
{
    public class Position
    {
        public int Index
        {
            get => index;
        }

        public int Value
        {
            get => value;
        }


        private int index;
        private int value;
        private bool status;
        private bool fixedPosition;
        public Position(int index,int value, bool status)
        {
            this.index = index;
            this.value = value;
            this.status = status;
        }

        public bool IsOpen()
        {
            return status;
        }

        public bool IsNotOpen()
        {
            return !IsOpen();
        }
        public bool IsFixed()
        {
            return fixedPosition;
        }

        public bool IsnotFixed()
        {
            return !IsFixed();
        }
        

        public void Open()
        {
            status = true;
        }

        public void Hide()
        {
            status = false;
        }

        public void FixPosition()
        {
            fixedPosition = true;
        }
    }
}
