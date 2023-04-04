from PIL import Image
import os

# 입력 폴더 경로
input_folder = "C:/Users/SangHyeon/Unity Project/Room_Escape_Project/Assets/AtmosphericHouse/Textures"

# 출력 폴더 경로
output_folder = "/path/to/output/folder"

# 이미지 크기
size = (1024, 1024)

img_path_list = []
possible_img_extension = ['.jpg', '.jpeg', '.JPG', '.bmp', '.png'] # 이미지 확장자들
 
for (root, dirs, files) in os.walk(input_folder):
    if len(files) > 0:
        for file_name in files:
            if os.path.splitext(file_name)[1] in possible_img_extension:
                img_path = root + '/' + file_name

                # 경로에서 를 모두 /로 바꿔줘야함
                img_path = img_path.replace('\\', '/') # 는 \로 나타내야함
                img_path_list.append(img_path)

# 입력 폴더 내의 모든 파일을 가져옴
for filename in img_path_list:
    # 파일 경로
    input_path = os.path.join(input_folder, filename)

    # 파일 확장자
    extension = os.path.splitext(filename)[1].lower()

    # 이미지 파일인 경우에만 처리
    if extension in ['.jpg', '.jpeg', '.png', '.bmp']:
        # 이미지 파일 열기
        with Image.open(input_path) as img:
            # 이미지 크기 조정
            img.thumbnail(size)

            # 출력 파일 경로
            output_path = os.path.join(input_folder, filename)

            # 이미지 저장
            img.save(output_path)

            print(f"{filename} has been resized and saved.")
