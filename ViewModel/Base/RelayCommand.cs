using System;
using System.Windows.Input;

namespace Uiprogramming
{ 

    class RelayCommand : ICommand
    {
        #region Private Members
        // creats 2 delegates:
        // Action delegate stores the method that will be executed
        // Predicate delegate will check whether the method CAN be executed. If it can't it will grey out the caller (ie. a button)
        readonly Action __execute;
        readonly Action<object> _execute;
        readonly Predicate<object> _canexecute;

        #endregion

        #region Constructors
        //Relaycommand takes in 2 delegates for execution of the method pointed to by the Action delegate
        public RelayCommand (Action<object> execute, Predicate<object> canexecute)
        {
            _execute = execute ?? throw new NullReferenceException("execute"); // if null then no method will execute hence null reference exception
            _canexecute = canexecute;
        }

        // if we only pass an action delegate to the constructor, then this constructor will add a predicate delegate of null
        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        public RelayCommand(Action execute, Predicate<object> canexecute)
        {
            __execute = execute ?? throw new NullReferenceException("execute");
            _canexecute = canexecute;
        }

        public RelayCommand(Action execute) : this(execute, null)
        {

        }
        #endregion

        #region Public events
        // something about checking if the CanExecute will change??
        // The event CanExecuteChanged fires when there is a change detected in the caller by the CommandManager. 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Command Methods
        //if canexecute is null then it has not been instantiated. If so, return true so that the button is not unclickable. 
        //This is useful for those commands that will fire off without any conditions attached.
        public bool CanExecute(object parameter)
        {
            return _canexecute == null ? true : _canexecute(parameter);
        }

        //the execute delegate is invoked which takes in a parameter.
        public void Execute(object parameter)
        {
            if (parameter == null)
            {
                __execute.Invoke();
            }
            else
            {
                _execute.Invoke(parameter);
            }
        }
        #endregion

    }
}
