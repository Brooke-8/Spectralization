# Spectralization

Prototype rhythm game that takes audio directly from desktop. Has a visualizer that reacts to audio from given input device and audio data used for game logic. 
Currently has a couple second delay between source audio and the game, this is so that the game as time to read and process the data, hopefully can improve in the future.

![SpectralizationDemo](https://github.com/user-attachments/assets/7cfa97aa-b19f-4ca4-8c6c-7ae6af0f72a4)

##

Requires method to route audio from the source application to the game application. Here are a few options that I know of:
- Hardware Options
  - Mixer/Audio cables
  - Directly from microphone (Not Recommened)
- Software Options
  - VB-Audio Software
  - Soundsync
  - Virtual Audio Cable (VAC)
  - Built-In drivers

##

Setup Instructions:
- Download exe
- Find method to route audio as an input device (It should appear as a microphone or similar in your input devices) (Looking for ways to integrate this directly into the app in the future or at least make simpler)
- Open game and select that input device under options 

