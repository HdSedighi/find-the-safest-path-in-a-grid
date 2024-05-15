# Intuition
<!-- Describe your first thoughts on how to solve this problem. -->
The problem involves finding a path from the top-left corner to the bottom-right corner of a grid while maximizing the minimum distance from any point on the path to the nearest thief. This suggests a need to calculate the distance to the nearest thief for each cell and then find a path that maximizes the smallest of these distances. This can be achieved by using Breadth-First Search (BFS) to determine the distances and Dijkstra's algorithm to find the safest path.

# Approach
<!-- Describe your approach to solving the problem. -->
1. Calculate Distances Using BFS:

- Initialize a distances matrix where each cell will store the minimum distance to any thief.
- Perform a BFS starting from all thief positions simultaneously, updating the distance for each cell.
2. Find the Safest Path Using Dijkstra's Algorithm:

- Use a priority queue (max-heap) to process cells in the order of their safeness factor.
- Start from the top-left corner and traverse the grid, always choosing the path that maximizes the minimum distance to a thief.
- Continue this process until you reach the bottom-right corner, at which point the safeness factor of the path is determined.
# Complexity
- Time complexity:
<!-- Add your time complexity here, e.g. $$O(n)$$ -->
The BFS to calculate the distances runs in O(n^2)since it processes each cell once.

Dijkstra’s algorithm, with the priority queue, also runs in O(n ^ 2 logn) due to the heap operations for each cell.

- Space complexity:

<!-- Add your space complexity here, e.g. $$O(n)$$ -->
The space complexity is O(n^2) for storing the distances matrix and the visited matrix. The priority queue will also take O(n^2) space in the worst case.
