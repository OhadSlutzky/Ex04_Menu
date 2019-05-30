using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Function : MenuItem
    {
        private List<IClicked> m_FunctionListeners;

        public Function(string i_Title) : base(i_Title)
        {
            m_FunctionListeners = new List<IClicked>();
        }

        public List<IClicked> FunctionListeners
        {
            get
            {
                return m_FunctionListeners;
            }
        }

        public void AddClickedListener(IClicked i_Listener)
        {
            if (i_Listener != null)
            {
                m_FunctionListeners.Add(i_Listener);
            }
            else
            {
                throw new ArgumentNullException("The item you tried to add was null ! ! !");
            }
        }

        public void RemoveClickedListener(IClicked i_Listener)
        {
            m_FunctionListeners.Remove(i_Listener);
        }

        public void Invoke()
        {
            foreach (IClicked clicked in m_FunctionListeners)
            {
                clicked.MethodInvoke(this.m_Title);
            }
        }
    }

}
