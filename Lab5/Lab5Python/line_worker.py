from Line import *
from Point import *
from random import randint


def print_list(lst, pre_print=""):
    print(pre_print)
    for item in lst:
        print(item)
    print()


def perpendicular_to_all(lines: list[Line]):
    for ind_to_check in range(len(lines)):
        perp_line = lines[ind_to_check]
        perpendicular = True
        for j in range(len(lines)):
            if ind_to_check != j:
                if not lines[ind_to_check].is_perpendicular_to(lines[j]):
                    perpendicular = False
                    break
        if perpendicular:
            return perp_line


def get_random_line2d(rand_min=-5, rand_max=6) -> Line2D:
    a = Point2D(randint(rand_min, rand_max), randint(rand_min, rand_max))
    b = Point2D(randint(rand_min, rand_max), randint(rand_min, rand_max))
    return Line2D(a, b)


def get_random_line3d(rand_min=-5, rand_max=6) -> Line3D:
    a = Point3D(randint(rand_min, rand_max), randint(rand_min, rand_max), randint(rand_min, rand_max))
    b = Point3D(randint(rand_min, rand_max), randint(rand_min, rand_max), randint(rand_min, rand_max))
    return Line3D(a, b)


def get_random_line2d_list(size) -> list[Line2D]:
    return [get_random_line2d() for i in range(size)]


def get_random_line3d_list(size) -> list[Line3D]:
    return [get_random_line3d() for i in range(size)]
