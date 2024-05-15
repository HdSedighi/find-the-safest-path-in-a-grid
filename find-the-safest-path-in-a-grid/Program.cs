using System;
using System.Collections.Generic;

public class Solution {
    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        int[][] distances = new int[n][];
        for (int i = 0; i < n; i++) {
            distances[i] = new int[n];
            for (int j = 0; j < n; j++) {
                distances[i][j] = int.MaxValue;
            }
        }

        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        for (int r = 0; r < n; r++) {
            for (int c = 0; c < n; c++) {
                if (grid[r][c] == 1) {
                    queue.Enqueue((r, c));
                    distances[r][c] = 0;
                }
            }
        }

        int[] dr = new int[] { -1, 1, 0, 0 };
        int[] dc = new int[] { 0, 0, -1, 1 };

        while (queue.Count > 0) {
            var (r, c) = queue.Dequeue();
            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];
                if (nr >= 0 && nr < n && nc >= 0 && nc < n && distances[nr][nc] == int.MaxValue) {
                    distances[nr][nc] = distances[r][c] + 1;
                    queue.Enqueue((nr, nc));
                }
            }
        }

        PriorityQueue<(int r, int c, int minDistance), int> pq = new PriorityQueue<(int r, int c, int minDistance), int>(Comparer<int>.Create((a, b) => b - a));
        pq.Enqueue((0, 0, distances[0][0]), distances[0][0]);
        bool[,] visited = new bool[n, n];

        while (pq.Count > 0) {
            var (r, c, minDistance) = pq.Dequeue();
            if (r == n - 1 && c == n - 1) {
                return minDistance;
            }
            if (visited[r, c]) continue;
            visited[r, c] = true;

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];
                if (nr >= 0 && nr < n && nc >= 0 && nc < n && !visited[nr, nc]) {
                    int newMinDistance = Math.Min(minDistance, distances[nr][nc]);
                    pq.Enqueue((nr, nc, newMinDistance), newMinDistance);
                }
            }
        }

        return 0;
    }
}
