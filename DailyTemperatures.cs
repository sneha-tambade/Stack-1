
// Use a monotonic decreasing stack to store indices of days whose warmer temperature hasn’t been found yet.
// Traverse the array once; when the current temperature is higher than the stack’s top index temperature, pop and calculate the difference (i - popped).
// Push each index onto the stack, ensuring each element is processed at most twice (push + pop).

//TC - O(2n)=O(n)
//SC - O(n)
public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] answers = new int[n];
        Stack<int> st = new();
        for (int i = 0; i < n; i++)
        {
            while (st.Count > 0 && temperatures[i] > temperatures[st.Peek()])
            {
                int popped = st.Pop();
                answers[popped] = i - popped;
            }
            st.Push(i);
        }
        return answers;
    }
}