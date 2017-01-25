import os
import json


class GameImageData:

    def __init__(self, asset_name, is_male, is_crossdresser, penalty, reward):
        self.asset_name = asset_name
        self.is_male = is_male
        self.is_crossdresser = is_crossdresser
        self.penalty = penalty
        self.reward = reward


class GameImageDataDecoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, GameImageData):
            return {
                "assetName": obj.asset_name,
                "isMale": obj.is_male,
                "isCrossdresser": obj.is_crossdresser,
                "penalty": obj.penalty,
                "reward": obj.reward
            }
        # Let the base class default method raise the TypeError
        return json.JSONEncoder.default(self, obj)


input_files = os.listdir("images/")
normalized_input_files = []

for file_name in input_files:
    if not file_name.startswith("."):
        if not file_name.endswith(".jpg"):
            raise Exception("wrong file extension, only jpg allowed: {}"
                            .format(file_name))
        normalized_input_files.append(file_name)

print("input files: {}".format(normalized_input_files))

game_images_data = []

for file_name in normalized_input_files:
    file_name_without_extension = file_name.replace(".jpg", "")
    name_data = file_name_without_extension.split("_")

    is_male = True
    is_male_char = name_data[1]
    if is_male_char == 'm':
        is_male = True
    elif is_male_char == 'f':
        is_male = False
    else:
        raise Exception("wrong is_male value: {}".format(file_name))

    is_crossdresser = True
    is_crossdresser_char = name_data[2]
    if is_crossdresser_char == 'c':
        is_crossdresser = True
    elif is_crossdresser_char == 'n':
        is_crossdresser = False
    else:
        raise Exception("wrong is_crossdresser value: {}".format(file_name))

    game_images_data.append(GameImageData(
        asset_name=file_name_without_extension,
        is_male=is_male,
        is_crossdresser=is_crossdresser,
        penalty=int(name_data[3]),
        reward=int(name_data[4])
    ))

json_output = json.dumps(game_images_data, cls=GameImageDataDecoder,
                         sort_keys=True, indent=4, separators=(',', ': '))
file = open('images_data.json', 'w+')
file.write(json_output)
file.flush()
file.close()

print("game_images_data: {}".format(json_output))
