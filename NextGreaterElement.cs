//TC - O(4n)=O(n)
//SC - O(n)

//Approach
// Use a monotonic decreasing stack to store indices whose next greater element hasn’t been found yet.
// Traverse the array twice (0 → 2n) using i % n to simulate circular behavior.
// Whenever current element is greater than stack top element, pop and update its answer.
public class Solution
{
    public int[] NextGreaterElements(int[] nums)
    {
        int n = nums.Length;
        int[] answer = new int[n];
        Stack<int> stack = new();
        for (int i = 0; i < 2 * n; i++)
        {
            if (i < n)
            {
                answer[i] = -1;
            }

            int nextidx = i % n;
            while (stack.Count > 0 && nums[nextidx] > nums[stack.Peek()])
            {
                int popped = stack.Pop();
                answer[popped] = nums[nextidx];
            }
            if (i < n)
            {
                stack.Push(i);
            }
        }

        return answer;
    }
}