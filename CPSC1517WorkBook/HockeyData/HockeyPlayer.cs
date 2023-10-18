using System.Globalization;
using Utils;

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
        private int _jerseyNumber;

        // properties
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birth place cannot be null or empty.");
                }

                // if we get here, then no exception happened
                _birthPlace = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }

                // if we get here, then no exception happened
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            private set
            {
                if (Utilities.IsNullEmptyOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }

                // if we get here, then no exception happened
                _lastName = value;
            }
        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }

            private set
            {
                if (Utilities.IsZeroOrNegative(value))
                {
                    throw new ArgumentException("Height must be positive.");
                }

                _heightInInches = value;
            }
        }

        public int WeightInPounds
        {
            get
            {
                return _weightInPounds;
            }

            private set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException("Weight must be positive.");
                }

                _weightInPounds = value;
            }
        }
        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            private set
            {
                if (Utilities.IsInTheFuture(value))
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }

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
            int weightInPounds, int heightInInches, int jerseyNumber, Position position = Position.Center, Shot shot = Shot.Left)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthPlace = birthPlace;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            JerseyNumber = jerseyNumber;
            DateOfBirth = dateOfBirth;
            Position = position;
            Shot = shot;
        }

        public int JerseyNumber
        {
            get
            {
                return _jerseyNumber;
            }

            set
            {
                if (value < 1 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("Jersey number must be between 1 and 98.",
                        new ArgumentException());
                }

                _jerseyNumber = value;
            }
        }

        public int Age => (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

        // Override of ToString
        public override string ToString()
        {
            return $"{FirstName},{LastName},{JerseyNumber},{Position},{Shot},{HeightInInches},{WeightInPounds},{DateOfBirth.ToString("MMM-dd-yyyy", CultureInfo.InvariantCulture)},{BirthPlace}";
        }

        public static HockeyPlayer Parse(string line)
        {
            // Expected line format
            // FirstName,LastName,JerseyNumber,Position,Shot,Height,Weight,DOB,BirthPlace
            // 0         1        2            3        4    5      6      7   8

            // Split on commas
            string[] fields = line.Split(',');

            HockeyPlayer player;

            player = new HockeyPlayer(fields[0], fields[1], fields[8], 
                DateOnly.ParseExact(fields[7], "MMM-dd-yyyy", CultureInfo.InvariantCulture),
                int.Parse(fields[6]), int.Parse(fields[5]), int.Parse(fields[2]),
                Enum.Parse<Position>(fields[3]), Enum.Parse<Shot>(fields[4]));

            return player;
        }
    }
}