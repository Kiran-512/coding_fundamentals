#include <iostream>
#include <unordered_map>

class ListNode
{
public:
    int val;
    ListNode *next;
    ListNode(int val) : val(val), next(nullptr) {}
};

class SinglyLinkedList
{
private:
    ListNode *head;
    ListNode *tail;
    int size;

public:
    // Method to insert in the linked list
    void insert(int val)
    {
        ListNode *newNode = new ListNode(val);
        size++;
        if (!head) // if(head == nullptr)
        {
            head = newNode;
            tail = newNode;
            return;
        }
        tail->next = newNode;
        tail = newNode;
    }
    // Method to add w/o tail, assume tail doesn't exist
    void insertWithoutTail(int val)
    {
        ListNode *newNode = new ListNode(val);
        size++;
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
    }

    // insert at index
    void insertAtIndex(int val, int index)
    {
        if (index < 0 || index > size)
        {
            return;
        }
        size++;
        ListNode *newNode = new ListNode(val);
        if (index == 0)
        {
            newNode->next = head;
            head = newNode;
            return;
        }
        ListNode *temp = head;
        while (index != 1)
        {
            temp = temp->next;
            index--;
        }
        newNode->next = temp->next;
        temp->next = newNode;
    }

    // Method to delete from the linked list
    void deleteNode(int val)
    {
        ListNode *temp = head;
        ListNode *prev = nullptr;
        size--;
        while (temp)
        {
            if (temp->val == val)
            {
                if (prev)
                {
                    prev->next = temp->next;
                }
                else
                {
                    head = temp->next;
                }
                delete temp;
                return;
            }
            prev = temp;
            temp = temp->next;
        }
    }
    // delete from a index
    void deleteAtIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            return;
        }
        size--;
        ListNode *temp = head;
        ListNode *prev = nullptr;
        while (index != 1)
        {
            temp = temp->next;
            prev = temp;
            index--;
        }
        if (prev)
        {
            prev->next = temp->next;
        }
        else
        {
            head = temp->next;
        }
        temp = nullptr;
        delete temp;
    }

    // Method to reverse the linked list
    ListNode *reverse(ListNode *head)
    {
        ListNode *curr = head;
        ListNode *prev = nullptr;
        while (curr)
        {
            ListNode *next = curr->next;
            curr->next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }
    ListNode *reverseRecursiveHelper(ListNode *curr, ListNode *prev)
    {
        if (!curr)
        {
            return prev;
        }
        ListNode *next = curr->next;
        curr->next = prev;
        return reverseRecursiveHelper(next, curr);
    }
    ListNode *reverseRecursive(ListNode *head)
    {
        return reverseRecursiveHelper(head, nullptr);
    }

    // Method to find the middle of the linked list
    ListNode *findMiddle(ListNode *head)
    {
        // Use two pointers, one moving at twice the speed of the other
        ListNode *fast = head;
        ListNode *slow = head;
        while (fast && fast->next)
        {
            fast = fast->next->next;
            slow = slow->next;
        }
        return slow;
    }

    // Method to find the nth node from the end of the linked list
    // Example: 1->2->3->4->5->6->7->8->9->10, n=3, output: 8
    void findNthNodesFromEndHelper(ListNode *it, int n, ListNode *&result)
    {
        if (!it)
        {
            return;
        }
        findNthNodesFromEndHelper(it->next, n, result);
        if (n == 0)
            result = it;
        n--;
    }
    ListNode *findNthNodesFromEndRec(ListNode *head, int n)
    {
        ListNode *result = nullptr;
        findNthNodesFromEndHelper(head, n, result);
        return result;
    }
    // Examlpe with each lines status pointers
    ListNode *findNthNodeFromEnd(ListNode *head, int n)
    {
        // 1->2->3->4->5->6->7->8->9->10 n=3
        ListNode *fast = head;
        // fast : 1
        ListNode *slow = head;
        // slow : 1

        // used two pointere here becasue if fast pointers reaches to the end of the linked list
        // then slow pointer will be at the nth node from the end of the linked list
        while (n--)
        {
            if (!fast)
            {
                return nullptr;
            }
            fast = fast->next;
        }
        // fast : 4
        while (fast)
        {
            fast = fast->next;
            slow = slow->next;
        }
        // slow : 8
        // fast : 10
        return slow;
    }

    // Method to remove the nth node from the end of the linked list
    void removeNthNodeFromLinkedList(int n)
    {
        ListNode *fast = head;
        ListNode *slow = head;
        while (n--)
        {
            if (!fast)
            {
                return; // n is greater than the size of the linked list
            }
            fast = fast->next;
        }
        ListNode *prev = nullptr;
        while (fast)
        {
            fast = fast->next;
            prev = slow;
            slow = slow->next;
        }
        if (prev)
        {
            prev->next = slow->next;
        }
        else
        {
            head = slow->next;
        }
        delete slow;
    }

    // Method to check if the linked list has a cycle using map
    bool hasCycle(ListNode *head)
    {
        unordered_map<ListNode *, bool> visited;
        ListNode *temp = head;
        while (temp)
        {
            if (visited[temp])
            {
                return true;
            }
            visited[temp] = true;
            temp = temp->next;
        }
        return false;
    }

    // Method to check if the linked list has a cycle using two pointers
    // Time complexity: O(n)
    // Space complexity: O(1)
    bool hasCycleTwoPointers(ListNode *head)
    {
        ListNode *slow = head;
        ListNode *fast = head;
        while (fast && fast->next)
        {
            slow = slow->next;
            fast = fast->next->next;
            if (slow == fast)
            {
                return true;
            }
        }
        return false;
    }

    // Method to detect the starting node of the cycle in the linked list
    ListNode *detectStartingPointOfCycle(ListNode *head)
    {
        ListNode *slow = head;
        ListNode *fast = head;
        while (fast && fast->next)
        {
            slow = slow->next;
            fast = fast->next->next;
            if (slow == fast)
            {
                break;
            }
        }
        if (!fast || !fast->next)
        {
            return nullptr; // case when there is no cycle, return nullptr
        }
        slow = head;
        while (slow != fast)
        {
            slow = slow->next;
            fast = fast->next;
        }
        return slow;
    }

    // Method to remove the cycle in the linked list
    void removeCycle(ListNode *head)
    {
        ListNode *slow = head;
        ListNode *fast = head;
        while (fast && fast->next)
        {
            slow = slow->next;
            fast = fast->next->next;
            if (slow == fast)
            {
                break;
            }
        }
        if (!fast || !fast->next)
        {
            return; // case when there is no cycle
        }
        slow = head;
        while (slow->next != fast->next)
        {
            slow = slow->next;
            fast = fast->next;
        }
        fast->next = nullptr;
    }

    // Method to merge two sorted linked lists
    ListNode *mergeTwoLists(ListNode *l1, ListNode *l2)
    {
        ListNode *dummy = new ListNode(0);
        ListNode *temp = dummy;
        while (l1 && l2)
        {
            if (l1->val < l2->val)
            {
                temp->next = l1;
                l1 = l1->next;
            }
            else
            {
                temp->next = l2;
                l2 = l2->next;
            }
            temp = temp->next;
        }
        if (l1)
        {
            temp->next = l1;
        }
        if (l2)
        {
            temp->next = l2;
        }
        return dummy->next;
    }

    // Method to merge k sorted linked lists using heap
    ListNode *mergeKLists(vector<ListNode *> &lists)
    {
        auto cmp = [](ListNode *a, ListNode *b)
        { return a->val > b->val; };
        priority_queue<ListNode *, vector<ListNode *>, decltype(cmp)> pq(cmp);
        for (ListNode *list : lists)
        {
            if (list)
            {
                pq.push(list);
            }
        }
        ListNode *dummy = new ListNode(0);
        ListNode *temp = dummy;
        while (!pq.empty())
        {
            ListNode *top = pq.top();
            pq.pop();
            temp->next = top;
            temp = temp->next;
            if (top->next)
            {
                pq.push(top->next);
            }
        }
        return dummy->next;
    }

    // Method to sort the linked list
    ListNode *sortList(ListNode *head)
    {
        if (!head || !head->next)
        {
            return head;
        }
        ListNode *middle = findMiddle(head);
        ListNode *nextToMiddle = middle->next;
        middle->next = nullptr;
        ListNode *left = sortList(head);
        ListNode *right = sortList(nextToMiddle);
        return mergeTwoLists(left, right);
    }

    // Method to rotate the linked list to the right by k places
    // next method

    // Method to check if the linked list is a palindrome
    bool isPalindrome(ListNode *head)
    {
        if (!head || !head->next)
        {
            return true;
        }
        ListNode *middle = findMiddle(head);
        ListNode *nextToMiddle = middle->next;
        middle->next = nullptr;
        nextToMiddle = reverse(nextToMiddle);
        while (nextToMiddle)
        {
            if (head->val != nextToMiddle->val)
            {
                return false;
            }
            head = head->next;
            nextToMiddle = nextToMiddle->next;
        }
        return true;
    }

    // Method to copy a linked list with random pointers
    ListNode *copyRandomList(ListNode *head)
    {
        unordered_map<ListNode *, ListNode *> mp;
        ListNode *temp = head;
        while (temp)
        {
            mp[temp] = new ListNode(temp->val);
            temp = temp->next;
        }
        temp = head;
        while (temp)
        {
            mp[temp]->next = mp[temp->next];
            mp[temp]->random = mp[temp->random];
            temp = temp->next;
        }
        return mp[head];
    }

    // Method to flatten a linked list
    ListNode *flatten(ListNode *head)
    {
        if (!head)
        {
            return nullptr;
        }
        ListNode *temp = head;
        while (temp->next)
        {
            ListNode *next = temp->next;
            temp->next = mergeTwoLists(temp, next);
            temp = temp->next;
        }
        return temp;
    }

    // Method to reorder the linked list such that the first node's next points to the last node, the second node's next points to the second last node, and so on
    // Example : 1->2->3->4->5->6->7->8->9->10, output: 1->10->2->9->3->8->4->7->5->6
    void reorderList(ListNode *head)
    {
        if (!head || !head->next)
        {
            return;
        }
        ListNode *middle = findMiddle(head);
        ListNode *nextToMiddle = middle->next;
        middle->next = nullptr;
        nextToMiddle = reverse(nextToMiddle);
        ListNode *temp = head;
        while (nextToMiddle)
        {
            ListNode *next = temp->next;
            temp->next = nextToMiddle;
            nextToMiddle = nextToMiddle->next;
            temp->next->next = next;
            temp = next;
        }
    }

    // Method to swap pairs of nodes in the linked list
    // Example : 1->2->3->4->5->6->7->8->9->10, output: 2->1->4->3->6->5->8->7->10->9
    ListNode *swapPairs(ListNode *head)
    {
        if (!head || !head->next)
        {
            return head;
        }
        ListNode *dummy = new ListNode(0);
        dummy->next = head;
        ListNode *temp = dummy;
        while (temp->next && temp->next->next)
        {
            ListNode *first = temp->next;
            ListNode *second = temp->next->next;
            first->next = second->next;
            second->next = first;
            temp->next = second;
            temp = first;
        }
        return dummy->next;
    }

    // Method to reverse every k nodes in the linked list
    // Example : 1->2->3->4->5->6->7->8->9->10, k=3, output: 3->2->1->6->5->4->9->8->7->10
    ListNode *reverseKGroup(ListNode *head, int k)
    {
        ListNode *dummy = new ListNode(0);
        dummy->next = head;
        ListNode *prev = dummy;
        ListNode *curr = head;
        while (curr)
        {
            ListNode *start = curr;
            ListNode *end = curr;
            int count = 1;
            while (count < k && end)
            {
                end = end->next;
                count++;
            }
            if (!end)
            {
                break;
            }
            ListNode *next = end->next;
            end->next = nullptr;
            prev->next = reverse(start);
            start->next = next;
            prev = start;
            curr = next;
        }
        return dummy->next;
    }

    // Method to add two numbers represented by linked lists
    // Example : 1->2->3->4->5->6->7->8->9->10, 1->2->3->4->5->6->7->8->9->10, output: 2->4->6->9->1->3->5->7->9->0
    ListNode *addTwoNumbers(ListNode *l1, ListNode *l2)
    {
        ListNode *dummy = new ListNode(0);
        ListNode *temp = dummy;
        int carry = 0;
        while (l1 || l2 || carry)
        {
            int sum = 0;
            if (l1)
            {
                sum += l1->val;
                l1 = l1->next;
            }
            if (l2)
            {
                sum += l2->val;
                l2 = l2->next;
            }
            sum += carry;
            carry = sum / 10;
            temp->next = new ListNode(sum % 10);
            temp = temp->next;
        }
        return dummy->next;
    }

    // recursive solution for above
    ListNode *addTwoNumbersRecursive(ListNode *l1, ListNode *l2, int carry = 0)
    {
        if (!l1 && !l2 && !carry)
        {
            return nullptr;
        }
        int sum = carry;
        if (l1)
        {
            sum += l1->val;
            l1 = l1->next;
        }
        if (l2)
        {
            sum += l2->val;
            l2 = l2->next;
        }
        ListNode *node = new ListNode(sum % 10);
        node->next = addTwoNumbersRecursive(l1, l2, sum / 10);
        return node;
    }

    // reverse between
    // Example : 1->2->3->4->5->6->7->8->9->10, m=3, n=7, output: 1->2->7->6->5->4->3->8->9->10
    ListNode *reverseBetween(ListNode *head, int m, int n)
    {
        if (m == n)
        {
            return head;
        }
        ListNode *dummy = new ListNode(0);
        dummy->next = head;
        ListNode *prev = dummy;
        for (int i = 0; i < m - 1; i++)
        {
            prev = prev->next;
        }
        ListNode *start = prev->next;
        ListNode *then = start->next;
        for (int i = 0; i < n - m; i++)
        {
            start->next = then->next;
            then->next = prev->next;
            prev->next = then;
            then = start->next;
        }
        return dummy->next;
    }
};

// methods to implment in singly linked list
//  1. insert
//  2. insertAtIndex
//  3. delete
//  4. deleteAtIndex
//  5. reverse
//  6. findMiddle
//  7. findNthFromEnd
//  8. removeNthFromEnd
//  9. hasCycle
//  10. detectCycle
//  11. removeCycle
//  12. mergeTwoLists
//  13. mergeKLists
//  14. sortList
//  15. rotateRight
//  16. isPalindrome
//  17. copyRandomList
//  18. flatten
//  19. reorderList
//  20. swapPairs
//  21. reverseKGroup
//  22. addTwoNumbers
//  23. deleteDuplicates
//  24. deleteDuplicatesII
//  25. partition
//  26. reverseBetween
//  27. insertionSortList
//  28. oddEvenList
//  29. deleteNodesWithGreaterValueOnRight
//  30. addTwoNumbersII
