namespace Barnett.Specification.Tests
{
    public sealed class Unit
    {
        private Unit()
        {
        }

        public static Unit None 
        {
            get 
            {
                if( _unit == null )
                {
                    lock( _padlock )
                    {
                        if( _unit == null )
                        {
                            _unit = new Unit();
                        }
                    }
                }

                return _unit; 
            }
        }

        //TODO: is readonly fine here or do we need the singlton pattern above?
        private static Unit _unit;
        private static readonly object _padlock = new object();
    }
}