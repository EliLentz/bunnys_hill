using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hill
{

    #region List
    /// <summary>
    /// here we will use a list to save and control all the bunnies
    /// </summary>
    class Hill<T>
    {
        Node<T> m_pHead; //first element of list
        Node<T> m_pTail; //last element of list
        Node<T> m_pCurrent; //current element of list
        int count = 0; //quantity of elements

        /// <summary>
        /// this method adds a new item to the end of the list
        /// </summary>
        /// <param name="data"></param>
        public void Push_Back(T data)
        {
            Node<T> node = new Node<T>(data);

            if (m_pHead == null)
            {
                m_pHead = node;
            }
            else
            {
                m_pTail.pnext = node;
                m_pTail.pnext.pprev = m_pTail;
            }

            m_pTail = node; 
            count++;
        }
        
        /// <summary>
        /// this method remove the element from list
        /// 
        /// Firstly, this method starts to search the needing element from begin
        /// if found, then deletes it
        /// if not found, it returns nothing
        /// </summary>
        /// <param name="data"></param>
        public void DeleteBunny(T data)
        {
            m_pCurrent = m_pHead;

            while (m_pCurrent != null)
            {

                if (m_pCurrent.Data.Equals(data))
                {
                    if (m_pCurrent == m_pHead)
                    {
                        m_pHead = m_pHead.pnext;
                        m_pHead.pprev = null;
                        m_pCurrent = m_pHead;
                    }
                    else if (m_pCurrent == m_pTail)
                    {
                        m_pTail = m_pTail.pprev;
                        m_pTail.pnext = null;
                        m_pCurrent = m_pTail;
                    }
                    count--;
                }
                else
                {
                    m_pCurrent = m_pCurrent.pnext;
                }
            }

            return;
        }
    }
    #endregion
    #region Node

    /// <summary>
    /// Constructor of Node for saving bunny
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public Node<T> pnext { get; set; }
        public Node<T> pprev { get; set; }
    }
    #endregion
}
