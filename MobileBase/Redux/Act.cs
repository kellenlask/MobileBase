using MobileBase.Collections;


namespace MobileBase.Redux
{
    public class Act
    {
        /// <summary>
        ///     The Redux Action's type.
        /// </summary>
        public readonly string ActionType;


        public Act()
        {
        }


        public Act(string actionType)
        {
            ActionType = actionType;
        }
    }



    public class ActWithParams<T> : Act
    {
        /// <summary>
        ///     The parameters to pass with the Action
        /// </summary>
        public readonly PropertyBag<T> Parameters;


        public ActWithParams() : base()
        {
        }


        public ActWithParams(string actionType, PropertyBag<T> parameters) : base(actionType)
        {
            Parameters = parameters;
        }
    }



    public class ActWithParams : ActWithParams<string>
    {
        public ActWithParams()
        {
        }


        public ActWithParams(string actionType, PropertyBag parameters) : base(actionType, parameters)
        {
        }
    }
}