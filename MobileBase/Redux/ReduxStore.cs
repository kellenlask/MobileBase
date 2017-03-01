using System;


namespace MobileBase.Redux
{
    public class ReduxStore<T>
    {
        // Locks
        private readonly object _stateLock = new object();

        private readonly Func<T, Act, T> _rootReducer;

        // Backing Fields
        private T _state;


//        public Delegate void MiddlewareFunc();


        /// <summary>
        ///     The store's root state. This would be the complete state tree for all state managed by this store.
        ///     Ideally, this would be immutable; however, C# doesn't make immutability easy -- you should, at a minimum,
        ///     treat this state as immutable.
        /// </summary>
        public T State
        {
            get {
                lock (_stateLock)
                {
                    return _state;
                }
            }
            private set
            {
                lock (_stateLock)
                {
                    _state = value;
                }
            }
        }


        /// <summary>
        ///     Creates a new Redux Store with the given initial state.
        /// </summary>
        /// <param name="rootReducer">The application reducer -- this is the reducer that calls into all others</param>
        /// <param name="initialState">The initial state for the store.</param>
        public ReduxStore(Func<T, Act, T> rootReducer, T initialState)
        {
            State = initialState;
            _rootReducer = rootReducer;
        }


        /// <summary>
        ///     Dispatches an action against the store -- as the store is "immutable", your action will be processed
        ///     through a series of pure functions to return a new instance of application state. All state change starts
        ///     with dispatching an action.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Act Dispatch(Act action)
        {
            State = _rootReducer(State, action);

            return action;
        }
    }
}