#include <iostream>
#include <vector>
#include <queue>
#include <cmath>

using namespace std;

struct Point {
    int x, y;
    Point(int _x, int _y) : x(_x), y(_y) {}
};

double distanceFromOrigin(const Point& p) {
    return p.x * p.x + p.y * p.y;
}

vector<Point> kClosestPoints(vector<Point>& points, int k) {
    auto compare = [](const Point& p1, const Point& p2) {
        return distanceFromOrigin(p1) < distanceFromOrigin(p2);
    };
    
    priority_queue<Point, vector<Point>, decltype(compare)> maxHeap(compare);
    
    for (const auto& point : points) {
        maxHeap.push(point);
        if (maxHeap.size() > k) {
            maxHeap.pop();
        }
    }
    
    vector<Point> result;
    while (!maxHeap.empty()) {
        result.push_back(maxHeap.top());
        maxHeap.pop();
    }
    
    return result;
}

int main() {
    vector<Point> points = { {1, 3}, {3, 4}, {2, -1} };
    int k = 2;
    
    vector<Point> closestPoints = kClosestPoints(points, k);
    
    cout << "The " << k << " closest points to the origin are:" << endl;
    for (const auto& point : closestPoints) {
        cout << "(" << point.x << ", " << point.y << ")" << endl;
    }
    
    return 0;
}