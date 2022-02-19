from os import system
import file_manager


def main():
    path1 = "D:\\BasicsOfProgramming(OOP)\\Lab2\\Lab2Python\\lab_files\\gadgets"
    path2 = "D:\\BasicsOfProgramming(OOP)\\Lab2\\Lab2Python\\lab_files\\not_warranty_gadgets"
    file_manager.fill_file_from_console(path1)

    gadgets = file_manager.get_gadgets_from_file(path1)
    warranty_gadgets = file_manager.get_not_warranty_gadgets(gadgets)

    file_manager.create_file(path2, file_manager.convert_gadgets_to_text(warranty_gadgets))

    file_manager.print_all_file(path1)
    file_manager.print_all_file(path2)


if __name__ == '__main__':
    main()
    system('pause')
