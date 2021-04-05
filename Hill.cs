namespace Hill
{

    #region ListWithIterator
    /// <summary>
    /// here we will use a list to save and control all the bunnies
    /// </summary>
    class Hill<T>
    {
        private Node<T> m_pHead; //first element of list
        private Node<T> m_pTail; //last element of list
        public Node<T> m_pCurrent { get;private set; } //current element of list
        public int count { get; private set; } //quantity of elements

        /// <summary>
        /// this method adds a new item to the end of the list
        /// </summary>
        /// <param name="data"></param>
        public void PushBack(T data)
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
        /// this method erases the node and swaps the value one back
        /// </summary>
        public void EraseNode()
        {
            if (m_pCurrent == null)
            {
                return;
            }

            if (m_pHead == m_pTail)
            {
                m_pCurrent = null;
            }
            else{
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
                else
                {
                    Node<T> ex_node = m_pCurrent;
                    m_pCurrent.pprev.pnext = m_pCurrent.pnext;
                    m_pCurrent.pnext.pprev = m_pCurrent.pprev;
                    m_pCurrent = m_pCurrent.pprev;
                    ex_node = null;
                }
            }
            count--;
        }

        /// <summary>
        /// returns the current value to the first node
        /// </summary>
        public void Reset()
        {
            if (m_pHead == null)
            {
                return;
            }
            m_pCurrent = m_pHead;
        }

        /// <summary>
        /// returns the value of the iterator one forward
        /// </summary>
        public void MoveNext()
        {
            if (m_pHead == null)
            {
                return;
            }else if (m_pCurrent == m_pTail || m_pHead == m_pTail)
            {
                m_pCurrent = m_pTail;
            }
            else
            {
                m_pCurrent = m_pCurrent.pnext;
            }
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