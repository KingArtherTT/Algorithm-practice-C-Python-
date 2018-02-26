using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(6);
            l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(4);
            l2.next = new ListNode(5);
            l2.next.next = new ListNode(6);

            ListNode result = AddTwoNumbers1_1(l1, l2);
            Console.ReadLine();
        }

        //没有抓住实质，实质是个位的数放到个位上，十位的数放到十位上
        public static ListNode AddTwoNumbers1_0(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode curr = result;
            ListNode h1 = l1;
            ListNode h2 = l2;
            while (h1!=null || h2!=null)
            {
                int a = h1 == null ? 0 : h1.val;
                int b = h2 == null ? 0 : h2.val;
                int sum = a + b+(curr.next!=null?curr.next.val:0);
                if (sum >= 10)
                {
                    ListNode nextNode = new ListNode(sum / 10);
                    ListNode node = new ListNode(sum % 10);
                    node.next = nextNode;
                    curr.next = node;
                    curr = node;
                }
                else
                {
                    ListNode node = new ListNode(sum);
                    curr.next = node;
                    curr = node;
                }
                if (h1!=null)
                {
                    h1 = h1.next;
                }
                if (h2!=null)
                {
                    h2 = h2.next;
                }
            }
            return result.next;
        }

        //进一步优化，抓住算法的核心是区分清楚哪个是个位上的数，哪个是十位上的数
        public static ListNode AddTwoNumbers1_1(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode curr = result;
            ListNode h1 = l1;
            ListNode h2 = l2;
            int carry = 0;//十位上的数
            while (h1 != null || h2 != null)
            {
                int a = h1 == null ? 0 : h1.val;
                int b = h2 == null ? 0 : h2.val;
                int sum = a + b + carry;
                carry = sum / 10;
                ListNode node = new ListNode(sum % 10);
                curr.next = node;
                curr = node;
                if (h1 != null)
                {
                    h1 = h1.next;
                }
                if (h2 != null)
                {
                    h2 = h2.next;
                }
            }
            //carry!=0 即加到最后一个 要满十进一 新增一位
            if (carry!=0)
            {
                curr.next = new ListNode(carry);
            }
            return result.next;
        }

        public ListNode AddTwoNumbers0_0(ListNode l1, ListNode l2)
        {
            if (l1.next == null && l1.val == 0)
            {
                return l2;
            }
            if (l2.next == null && l2.val == 0)
            {
                return l1;
            }
            string sl1 = "", sl2 = "";
            ListNode h1 = l1;
            while (h1 != null)
            {
                sl1 += h1.val;
                h1 = h1.next;
            }
            ListNode h2 = l2;
            while (h2 != null)
            {
                sl2 += h2.val;
                h2 = h2.next;
            }
            Char[] sl1Char = sl1.ToCharArray();
            Char[] sl2Char = sl2.ToCharArray();

            int count = sl1Char.Length > sl2Char.Length ? sl1Char.Length + 1 : sl2Char.Length + 1;
            int[] result = new int[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 0;
            }
            for (int i = 0; i < count; i++)
            {
                //先全部加完 然后依次整理成字符型数组
                int n1 = 0, n2 = 0;
                if (i + 1 <= sl1Char.Length)
                {
                    n1 = Convert.ToInt32(sl1Char[i].ToString());
                }
                if (i + 1 <= sl2Char.Length)
                {
                    n2 = Convert.ToInt32(sl2Char[i].ToString());
                }
                result[i] += n1 + n2;
                //满10进1
                if (result[i] >= 10 && i + 1 < count)
                {
                    result[i + 1] = result[i] / 10;
                    result[i] = result[i] % 10;
                }
            }

            ListNode resultNode = new ListNode(0);
            ListNode HNode = resultNode;
            for (int i = 0; i < (result[result.Length - 1] == 0 ? result.Length - 1 : result.Length); i++)
            {
                ListNode valNode = new ListNode(result[i]);
                HNode.next = valNode;
                HNode = valNode;
            }
            return resultNode.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
