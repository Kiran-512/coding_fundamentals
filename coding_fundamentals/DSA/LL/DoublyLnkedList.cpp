class ListNode
{
public:
    int val;
    ListNode *next;
    ListNode *prev;
    ListNode(int val) : val(val), next(nullptr), prev(nullptr) {}
};

class DoublyLinkedList
{
private:
    ListNode *head;
    ListNode *tail;
    int size;

public:
    void InsertAtBeginning(int val)
    {
        size++;
        ListNode *newNode = new ListNode(val);
        if (!head)
        {
            head = newNode;
            tail = newNode;
            return;
        }
        newNode->next = head;
        head->prev = newNode;
        head = newNode;
    }

    void InsertAtEnd(int val)
    {
        size++;
        ListNode *newNode = new ListNode(val);
        if (!head)
        {
            head = newNode;
            tail = newNode;
            return;
        }
        tail->next = newNode;
        newNode->prev = tail;
        tail = newNode;
    }

    void InsertAtEndWOtail(int val)
    {
        size++;
        ListNode *newNode = new ListNode(val);
        if (!head)
        {
            head = newNode;
            return;
        }
        ListNode *temp = head;
        while (temp->next)
        {
            temp = temp->next;
        }
        temp->next = newNode;
        newNode->prev = temp;
    }

    void InsertAtIndex(int val, int index)
    {
        if (index < 0 || index > size)
        {
            return;
        }
        if (index == 0)
        {
            InsertAtBeginning(val);
            return;
        }
        if (index == size)
        {
            InsertAtEnd(val);
            return;
        }
        size++;
        ListNode *newNode = new ListNode(val);
        ListNode *temp = head;
        while (index != 1)
        {
            temp = temp->next;
            index--;
        }
        newNode->next = temp->next;
        temp->next->prev = newNode;
        temp->next = newNode;
        newNode->prev = temp;
    }

    void DeleteFromBeginning()
    {
        if (!head)
        {
            return;
        }
        size--;
        ListNode *temp = head;
        head = head->next;
        if (head)
        {
            head->prev = nullptr;
        }
        delete temp;
    }

    void DeleteFromEnd()
    {
        if (!head)
        {
            return;
        }
        size--;
        ListNode *temp = head;
        while (temp->next != tail)
        {
            temp = temp->next;
        }
        delete tail;
        tail = temp;
        tail->next = nullptr;
    }

    void DeleteFromEndWOtail()
    {
        if (!head)
        {
            return;
        }
        size--;
        ListNode *temp = head;
        while (temp->next->next)
        {
            temp = temp->next;
        }
        delete temp->next;
        temp->next = nullptr;
    }

    void DeleteAtIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            return;
        }
        if (index == 0)
        {
            DeleteFromBeginning();
            return;
        }
        if (index == size - 1)
        {
            DeleteFromEnd();
            return;
        }
        size--;
        ListNode *temp = head;
        ListNode *prev = nullptr;
        while (index--)
        {
            prev = temp;
            temp = temp->next;
        }
        prev->next = temp->next;
        temp->next->prev = prev;
        delete temp;
    }

    // Example for DLL to reverse the list is
    //  1->2->3->4->5->6->7->8->9->10, output: 10->9->8->7->6->5->4->3->2->1
    void Reverse()
    {
        ListNode *temp = nullptr;
        ListNode *current = head;
        while (current)
        {
            temp = current->prev;
            current->prev = current->next;
            current->next = temp;
            current = current->prev;
        }
        if (temp)
        {
            head = temp->prev;
        }
    }

    ListNode *FindMiddle()
    {
        ListNode *fast = head;
        ListNode *slow = head;
        while (fast && fast->next)
        {
            fast = fast->next->next;
            slow = slow->next;
        }
        return slow;
    }

    ListNode *FindNthNodeFromEnd(int n)
    {
        ListNode *fast = head;
        ListNode *slow = head;
        while (n--)
        {
            if (!fast)
            {
                return nullptr;
            }
            fast = fast->next;
        }
        while (fast)
        {
            fast = fast->next;
            slow = slow->next;
        }
        return slow;
    }

    ListNode *FindNthNodeFromBeginning(int n)
    {
        ListNode *temp = head;
        while (n--)
        {
            if (!temp)
            {
                return nullptr;
            }
            temp = temp->next;
        }
        return temp;
    }

    int FindLengthWOSize()
    {
        int count = 0;
        ListNode *temp = head;
        while (temp)
        {
            count++;
            temp = temp->next;
        }
        return count;
    }

    int FindLength()
    {
        return size;
    }

    bool IsPalindromeForDLL()
    {
        ListNode *mid = FindMiddle();
        ListNode *temp = mid->prev;
        while (mid)
        {
            if (mid->val != temp->val)
            {
                return false;
            }
            mid = mid->next;
            temp = temp->prev;
        }
        return true;
    }
};

// Important methods of DoublyLinkedList
// 1. Insert at the beginning
// 2. Insert at the end
// 3. Insert at a given index
// 4. Delete from the beginning
// 5. Delete from the end
// 6. Delete from a given index
// 7. Reverse the linked list? needed for doubly linked list? no as we can traverse in both directions but needed for solving problems like palindrome and others such as reversing between m and n
// 8. Find the middle of the linked list
// 9. Find the nth node from the end of the linked list
// 10. Find the nth node from the beginning of the linked list
// 11. Find the length of the linked list
// 12. Palindrome linked list
// 13. Swap pairs of nodes in the linked list
