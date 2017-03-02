using System;
using System.Collections.Generic;
using System.Linq;
using MobileBase.Collections;


namespace MobileBase.AnonRedux
{
    /// <summary>
    ///     A Redux Store modeled off of JavaScript -- primarily around the use of anonymous data types. This is not
    ///     recommended use of C# -- but it will be interesting. Be aware, the DLR has worse performance.
    ///     See: https://msdn.microsoft.com/en-us/library/dd233052(v=vs.110).aspx
    /// </summary>
    public class Store
    {
        // Constants
        public delegate Func<Func<ReduxAction, dynamic>, Func<ReduxAction, dynamic>> MiddlewareFunc(dynamic state);

        // Internal State
        private readonly Dictionary<string, HashSet<Action<dynamic>>> _subscriptions;

        private readonly List<MiddlewareFunc> _middleware = new List<MiddlewareFunc>();

        // External State
        public dynamic State { get; private set; }


        public Store(Func<ReduxAction, dynamic, dynamic> rootReducer, dynamic initialState)
        {
            _subscriptions = new Dictionary<string, HashSet<Action<dynamic>>>();

            // Add root reducer and subscriber notifier as middleware



            State = initialState;
        }


        public ReduxAction Dispatch(ReduxAction action)
        {
            MiddlewareFunc seedFunc = state => state;

            // Apply Middleware
            var dispatch = _middleware.Aggregate(
                 seedFunc,
                 (func, middlewareFunc) => null
            );

            State = dispatch(State)(action);

            return action;
        }


        private void Notify(ReduxAction action)
        {
            _subscriptions[action.ActionType].ForEach(s => s?.Invoke(State));
        }


        public Action Subscribe(string actionType, Action<dynamic> action)
        {
            if (!_subscriptions.ContainsKey(actionType))
            {
                _subscriptions[actionType] = new HashSet<Action<dynamic>>();
            }

            _subscriptions[actionType].Add(action);

            return () => _subscriptions[actionType].Remove(action);
        }


        public Action AddMiddleware(MiddlewareFunc middleware)
        {
            _middleware.Add(middleware);
            return () => _middleware.Remove(middleware);
        }


        private MiddlewareFunc NotifySubscribers = state => next => action => {

            return action;
        };
    }



    public class ReduxAction
    {
        public string ActionType { get; }

        public dynamic ActionParams { get; }


        public ReduxAction(string actionType, dynamic actionParams)
        {
            ActionType = actionType;
            ActionParams = actionParams;
        }


        public ReduxAction(string actionType)
        {
            ActionType = actionType;
        }


        public ReduxAction(dynamic actionParams)
        {
            ActionParams = actionParams;
        }
    }
}