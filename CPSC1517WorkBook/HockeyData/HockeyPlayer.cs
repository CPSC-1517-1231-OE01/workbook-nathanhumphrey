namespace Hockey.Data
{
    public class HockeyPlayer
    {
        // data fields
        private string _firstName;
        private string _lastName;
        private string _birthPlace;
        private DateOnly _dateOfBirth;
        private int _heightInInches;
        private int _weightInPounds;
        // We don't need the following
        //private Position _position;
        //private Shot _shot;

        // properties
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birth place cannot be null or empty.");
                }

                // if we get here, then no exception happened
                _birthPlace = value;
            }
        }
        // TODO: complete the remaining string properties

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }

                _heightInInches = value;
            }
        }

        // TODO: complete the remaining int property
        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                // TODO: implement a validity check for dates in the future
                // Check the documentation for DateOnly
                _dateOfBirth = value;
            }
        }

        // Auto-implemented property
        public Position Position { get; set; }

        /// <summary>
        /// Represents the shot hand for a player
        /// </summary>
        public Shot Shot { get; set; }

        // constructors

        /// <summary>
        /// Creates a default instance of a HockeyPlayer
        /// </summary>
        public HockeyPlayer()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _birthPlace = string.Empty;
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Shot = Shot.Left;
            Position = Position.Center;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthPlace"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="weightInPounds"></param>
        /// <param name="heightInInches"></param>
        /// <param name="position"></param>
        /// <param name="shot"></param>
        public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, 
            int weightInPounds, int heightInInches, Position position = Position.Center, Shot shot = Shot.Left)
        {
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            Position = position;
            Shot = shot;
            // TODO: assign the remaining properties once you've completed them
        }

    }
}