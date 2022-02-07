from os import system
import file_manager
import input_manager
import text_manager


def main():
    first_file_name = "first_file"
    second_file_name = "second_file"

    text = input_manager.get_text_from_user()
    file_manager.generate_file(first_file_name, text)

    text_from_file1 = file_manager.read_all_from_file(first_file_name)
    text_from_file1 = text_manager.split_text_to_new_lines(text_from_file1)
    text_from_file1 = text_manager.define_longest_in_text(text_from_file1)

    file_manager.generate_file(second_file_name, text_from_file1)
    file_manager.print_from_file(first_file_name)
    file_manager.print_from_file(second_file_name)


if __name__ == '__main__':
    main()
    system("pause")

# string = "You are not special. " \
#          "You're not a beautiful and unique snowflake. " \
#          "You're the same decaying organic matter as everything else. " \
#          "We're all part of the same compost heap. " \
#          "We're all singing, all dancing crap of the world."
