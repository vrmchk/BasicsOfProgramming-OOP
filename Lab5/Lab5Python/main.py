from os import system
from line_worker import *


def main():
    point = Point2D(randint(-5, 6), randint(-5, 6))
    line2d_list = get_random_line2d_list(50)
    random_line3d = get_random_line3d_list(5)
    perpendicular_to_first = [l for l in line2d_list if l.is_perpendicular_to(line2d_list[0])]
    lines_with_point = [l for l in perpendicular_to_first if l.contains_point(point)]
    line3d_list = [Line3D(Point3D(1, 2, 3), Point3D(2, 3, 4)),
                   Line3D(Point3D(0, 0, 0), Point3D(1, 1, -2)), Line3D(Point3D(0, 0, 0), Point3D(2, 2, -4))]

    print_list(line2d_list, "2D Lines: ")
    print_list(perpendicular_to_first, "Lines, perpendicular to first")
    print_list(lines_with_point, f"Lines, perpendicular to first with point: {point}")
    print_list(random_line3d, "Random 3D Lines: ")
    print(f"Random 3D Line Perpendicular to all:\n{perpendicular_to_all(random_line3d)}")
    print_list(line3d_list, "3D Lines: ")
    print(f"3D Line Perpendicular to all:\n{perpendicular_to_all(line3d_list)}")


if __name__ == '__main__':
    main()
    system('pause')
