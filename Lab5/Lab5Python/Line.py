from abc import ABC, abstractmethod
from Point import *


class Line(ABC):
    @abstractmethod
    def is_parallel_to(self, line):
        pass

    @abstractmethod
    def is_perpendicular_to(self, line):
        pass

    @abstractmethod
    def contains_point(self, point):
        pass


class Line2D(Line):
    def __init__(self, a: Point2D, b: Point2D):
        if a != b:
            self.A = a
            self.B = b
            self.vector_coord = Point2D(b.x - a.x, b.y - a.y)

    def is_parallel_to(self, line):
        line: Line2D = line
        return line.vector_coord.x != 0 and line.vector_coord.y != 0 and \
               self.vector_coord.x / line.vector_coord.x == self.vector_coord.y / line.vector_coord.y

    def is_perpendicular_to(self, line):
        line: Line2D = line
        return self.vector_coord.x * line.vector_coord.x + self.vector_coord.y * line.vector_coord.y == 0

    def contains_point(self, point):
        point: Point2D = point
        line_with_point = Line2D(self.A, point)
        return self.is_parallel_to(line_with_point)

    def __str__(self):
        return f"A: {self.A}\t\tB: {self.B}"


class Line3D(Line):
    def __init__(self, a: Point3D, b: Point3D):
        if a != b:
            self.A = a
            self.B = b
            self.vector_coord = Point3D(b.x - a.x, b.y - a.y, b.z - a.z)

    def is_parallel_to(self, line):
        line: Line3D = line
        return line.vector_coord.x != 0 and line.vector_coord.y != 0 and line.vector_coord.z != 0 and \
               self.vector_coord.x / line.vector_coord.x == \
               self.vector_coord.y / line.vector_coord.y == self.vector_coord.z / line.vector_coord.z

    def is_perpendicular_to(self, line):
        line: Line3D = line
        return self.vector_coord.x * line.vector_coord.x + self.vector_coord.y * line.vector_coord.y + \
               self.vector_coord.z * line.vector_coord.z == 0

    def contains_point(self, point):
        point: Point3D = point
        line_with_point = Line3D(self.A, point)
        return self.is_parallel_to(line_with_point)

    def __str__(self):
        return f"A: {self.A}\t\tB: {self.B}"
