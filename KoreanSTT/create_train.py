import re, os, csv
from venv import create

def rule(x):
    # 괄호
    a = re.compile(r'\([^)]*\)')
    # 문장 부호
    b = re.compile('[^가-힣 ]')
    x = re.sub(pattern=a, repl='', string= x)
    x = re.sub(pattern=b, repl='', string= x)
    return x

def cereate_train(dataset_path: str):
    file_list = os.listdir(dataset_path)
    train = []

    for x in range(0, len(file_list), 2):
        with open(dataset_path + "/" + file_list[x + 1], 'r') as file:
            file_text = file.read()
            train.append((dataset_path + "/" +file_list[x], rule(file_text)))

    return train
            

def read_folder():
    dataset_path = input("데이터셋 폴터 경로를 입력하세요: ")
    train = cereate_train(dataset_path)

    with open('./train.txt', 'w') as file:
        for data in train:
            file.write(data[0] + '\t' + data[1])

def read_file():
    dataset_path = input("데이터셋 폴터 경로를 입력하세요: ")
    file_path = input("csv 파일 경로를 입력하세요: ")

    with open(file_path, 'r') as csv_file:
        rdr = csv.reader(csv_file)
        with open('./train.txt', 'w', encoding='utf-8') as train:
            for line in rdr:
                train.write(dataset_path + "\\" + line[0] + '.wav\t' + rule(line[1]) + '\n')

if __name__ == "__main__":
    read_file()