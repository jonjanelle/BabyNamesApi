using System;

namespace BabyNamesApi.Models
{
    public class State
    {
        private readonly StateCode _stateCode;
        public string Abbreviation { get; set; }
        public string Name => GetState(this._stateCode);

        public State(StateCode stateCode)
        {
            this._stateCode = stateCode;
            this.Abbreviation = this._stateCode.ToString();
        }

        private string GetState(StateCode state)
        {
            switch (state)
            {
                case StateCode.AL:
                    return "ALABAMA";

                case StateCode.AK:
                    return "ALASKA";

                case StateCode.AZ:
                    return "ARIZONA";

                case StateCode.AR:
                    return "ARKANSAS";

                case StateCode.CA:
                    return "CALIFORNIA";

                case StateCode.CO:
                    return "COLORADO";

                case StateCode.CT:
                    return "CONNECTICUT";

                case StateCode.DE:
                    return "DELAWARE";

                case StateCode.DC:
                    return "DISTRICT OF COLUMBIA";

                case StateCode.FL:
                    return "FLORIDA";

                case StateCode.GA:
                    return "GEORGIA";

                case StateCode.HI:
                    return "HAWAII";

                case StateCode.ID:
                    return "IDAHO";

                case StateCode.IL:
                    return "ILLINOIS";

                case StateCode.IN:
                    return "INDIANA";

                case StateCode.IA:
                    return "IOWA";

                case StateCode.KS:
                    return "KANSAS";

                case StateCode.KY:
                    return "KENTUCKY";

                case StateCode.LA:
                    return "LOUISIANA";

                case StateCode.ME:
                    return "MAINE";

                case StateCode.MD:
                    return "MARYLAND";

                case StateCode.MA:
                    return "MASSACHUSETTS";

                case StateCode.MI:
                    return "MICHIGAN";

                case StateCode.MN:
                    return "MINNESOTA";

                case StateCode.MS:
                    return "MISSISSIPPI";

                case StateCode.MO:
                    return "MISSOURI";

                case StateCode.MT:
                    return "MONTANA";

                case StateCode.NE:
                    return "NEBRASKA";

                case StateCode.NV:
                    return "NEVADA";

                case StateCode.NH:
                    return "NEW HAMPSHIRE";

                case StateCode.NJ:
                    return "NEW JERSEY";

                case StateCode.NM:
                    return "NEW MEXICO";

                case StateCode.NY:
                    return "NEW YORK";

                case StateCode.NC:
                    return "NORTH CAROLINA";

                case StateCode.ND:
                    return "NORTH DAKOTA";

                case StateCode.OH:
                    return "OHIO";

                case StateCode.OK:
                    return "OKLAHOMA";

                case StateCode.OR:
                    return "OREGON";

                case StateCode.PA:
                    return "PENNSYLVANIA";

                case StateCode.RI:
                    return "RHODE ISLAND";

                case StateCode.SC:
                    return "SOUTH CAROLINA";

                case StateCode.SD:
                    return "SOUTH DAKOTA";

                case StateCode.TN:
                    return "TENNESSEE";

                case StateCode.TX:
                    return "TEXAS";

                case StateCode.UT:
                    return "UTAH";

                case StateCode.VT:
                    return "VERMONT";

                case StateCode.VA:
                    return "VIRGINIA";

                case StateCode.WA:
                    return "WASHINGTON";

                case StateCode.WV:
                    return "WEST VIRGINIA";

                case StateCode.WI:
                    return "WISCONSIN";

                case StateCode.WY:
                    return "WYOMING";
            }

            throw new Exception("Not Available");
        }
    }
}
