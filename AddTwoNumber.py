class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None
#输入两个不为空的链表，代替两个非负整数，数字反向存储，每一个结点都包含一个数字；将这两个非负整数相加，并以链表的形式返回结果。
class Solution:
    def addTwoNumbers(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        """
        hl1=l1
        hl2=l2
        result=ListNode(0)
        curr=result
        sumR=0
        carry=0
        while hl1!= None or hl2!=None:
            if hl1!=None:
                a1=hl1.val
            else:
                a1=0
            if hl2!=None:
                a2=hl2.val
            else:
                a2=0
            sumR=a1+a2+carry
            carry=sumR//10
            node=ListNode(sumR%10)
            curr.next=node
            curr=node
            if hl1!=None:
                hl1=hl1.next
            if hl2!=None:
                hl2=hl2.next
        if carry!=0:
            curr.next=ListNode(carry)
        return(result.next)
    

l1=ListNode(1)
l1.next=ListNode(6)
l1.next.next=ListNode(3)
l2=ListNode(2)
l2.next=ListNode(5)
l2.next.next=ListNode(9)
result=Solution().addTwoNumbers(l1,l2)

print([l1.val,l1.next.val,l1.next.next.val],[l2.val,l2.next.val,l2.next.next.val],[result.val,result.next.val,result.next.next.val,result.next.next.next.val])
#迭代输出的函数