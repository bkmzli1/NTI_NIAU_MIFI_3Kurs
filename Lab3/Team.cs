namespace Lab3;

public class Team:IComparable
    {
        protected string _Organisation;
        public string Organisation
        {
            get { return _Organisation; }
            set { _Organisation = value; }
        }
         protected int _RegistrationNumber;
        public int RegistrationNumber {
            get { return _RegistrationNumber; }
            set {
                if (value <= 0) {
                    throw new ArgumentOutOfRangeException("Reg Num must be more than 0");
                }
            }
        }
        public int CompareTo(object obj) {
            Team tmp = obj as Team;
            if (tmp == null) {
                throw new ArgumentException("Wrong type!");
            }
            return _RegistrationNumber.CompareTo(tmp._RegistrationNumber);
        }
        // Constructor, which assigns specified values to the fields of class;
        public Team(string Organisation,int RegistrNumber) {
            _Organisation = Organisation;
            _RegistrationNumber = RegistrNumber;
        }
        public Team():this("Some Org",1) { }
        public virtual object DeepCopy() {
            return new Team(this.Organisation,this.RegistrationNumber);
        }
        public virtual new bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            Team objTeam = obj as Team;
            if (objTeam == null) {
                return false;
            }
            return this.Organisation == objTeam.Organisation && this.RegistrationNumber == objTeam.RegistrationNumber;
        }
        public static bool operator ==(Team l_Team, Team r_Team) {
            if (ReferenceEquals(l_Team, r_Team)) {
                return true;
            }
            if (((object)l_Team)==null&&((object)r_Team)==null) {
                return false;
            }
            return false; //(l_Team.Organisation == r_Team.Organisation);// && (l_Team.RegistrationNumber==r_Team.RegistrationNumber);
        }
        public static bool operator !=(Team l_Team, Team r_Team) {
            return !(l_Team == r_Team);
        }
        public virtual new int GetHashCode()
        {
            int HashCode = 0;
            foreach (char ch in _Organisation.ToCharArray())
            {
                HashCode += (int)Convert.ToUInt32(ch);
            }
            HashCode += _RegistrationNumber;
            return HashCode;
        }
        public virtual new string ToString()
        {
            return string.Format("Team of organisation {0} with registration number {1}", _Organisation, _RegistrationNumber);
        }
    }