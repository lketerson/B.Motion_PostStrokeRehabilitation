# B.Motion


B.Motion is an application developed as a proposal to help in the rehabilitation of paralised hand movements afected by stroke. This application was developed as a final project of my graduation in Computer Science.

## Leap Motion Controller Software Installation

To be able to use B.Motion with the Leap Motion Controller, the software must be installed. You can download it from this link:

https://drive.google.com/file/d/1R4-UZlZezal0wL2lGQGIXVIpdATBbrZ5/view?usp=sharing

It is currently not easy to find it online.

The .exe file is inside Leap_Motion_SDK --> Leap_Motion --> Leap_Motion_Setup.exe



## How To Play
When opening the game, the user will be presented with the following screen, in which he must select what type of role he will play when using the system. If you are a patient and need rehabilitation, you must select the “Patient” option to have access to the main menu regarding the patient's actions.

<p align="center">
  <img width="700" src="https://i.ibb.co/5BtBK73/imagem-2022-07-20-102530138.png">
</p>

When selecting the patient (PACIENTE) option, the user will be sent to the patient menu. Where he will have the options to watch the tutorials of execution of each of the exercises by clicking on the play/pause button. Being them the “Caixas e blocos” and the “Tempo de Reação”, in case the patient still does not know the execution flow of each of the levels. The menu screen contains several buttons that allow you to select activities or view performance graphs. They follow the following functionalities: The “Caixas e blocos” button that contains the symbol of a hand will take the patient to the first narrative. The “Tempo de Reação” button that contains the symbol of a brain will take the patient to the second narrative.
The buttons with the symbols of a graph with the names of “Caixas e blocos” and “Tempo de Reação” led to the performance graphs of each of the narratives respectively. The button with the arrow symbol will take the user to the function selection. The button with an x closes the application.

<p align="center">
  <img width="700" src="https://i.ibb.co/0Ds2WsV/imagem-2022-07-20-102559317.png">
</p>


When selecting the option "Boxes and Blocks" you will be redirected to the following screen. To get started, you need to fill in some information.

"Tempo da sessão" - How long each round will last in seconds.

"Quantidade de Sessões" - For how many rounds the player will perform the exercises. 

"Tempo de descanso" - The time in seconds that the patient will rest between each round.

"CPF" - Brazilian ID, for those who are not residents of Brazil, you can use the following link to generate a CPF for testing: https://www.4devs.com.br/gerador_de_cpf

The CPF field only accepts numbers.

The “confirm” button will send all the information and will start a 5-second counter, which the user must place both hands on the sensor so that it can identify both the right and the left, at the end of the time the patient must keep only the affected hand over the sensor.

<p align="center">
  <img width="700" src="https://i.ibb.co/zXtRxHB/image.png">
</p>

## Box and Blocks game
During the game, blocks with random colors between red, yellow, blue and green will appear under the user's virtual hand. These blocks must be placed inside their respective box respecting the colors.

Each correctly placed block will add one point, shown in the lower right corner, at the end of the time, shown in the lower left corner, a screen with a rest message ("DESCANSAR") will be shown. If one of the blocks is moved to a place where the user cannot reach, just press the spacebar and it will be replaced in its initial position.

While the rest message is on screen the player will have virtual hands disabled, until the time shown in the lower corner is equal to the rest time assigned in the settings screen.

Once the message disappears, the next session will start with the configured session time, this will be repeated until the number of sessions is satisfied. Once all the rouds are completed, the Game Over menu will be shown along with the patient's performance graph.

<p align="center">
  <img width="700" src="https://i.ibb.co/vqTMhdv/image.png">
</p>

In the game over menu it is possible to repeat the activity by clicking on the repeat button (REPETIR), at the top left, just below the repeat button, there is the button to return to the main menu (MENU PRINCIPAL).


The graph is calculated from the average of each complete session. It is an evolution graph, that is, the top of the graph (1.0) is always the maximum score, which can change as the patient surpass his own record. For example, if the max score is 6 points, this is the current max, but if it becomes 8, the graph will update the max score, making it 8-->1.0

<p align="center">
  <img width="700" src="https://i.ibb.co/tLh6JbW/image.png">
</p>

## Reaction Time Game
In these game there are two fields that must be filled.

"Quantidade de Sessões" - For how many rounds the player will perform the exercises.

"CPF" - Brazilian ID, for those who are not residents of Brazil, you can use the following link to generate a CPF for testing: https://www.4devs.com.br/gerador_de_cpf

Each round consists of 5 sub-rounds. The score is calculated from the average score of the sub-rounds.

<p align="center">
  <img width="700" src="https://i.ibb.co/9ypVNgz/image.png">
</p>

Once the settings are confirmed, the patient will go to the next screen, where it will be necessary for the patient to position the affected hand with the palm up so that the game can start.

<p align="center">
  <img width="700" src="https://i.ibb.co/CmYRKH9/image.png">
</p>

When the hand is correctly positioned, open and palm up, the patient will receive a blue screen indicating that is ready to start. At this time the patient should wait for the green color.

<p align="center">
  <img width="700" src="https://i.ibb.co/8xWVkxG/image.png">
</p>

If the patient rotates the palm downwards and clenches the fist during the green screen, his score will be counted from the time it took to perform the movement.

<p align="center">
  <img width="700" src="https://i.ibb.co/Q9WrW1j/image.png">
</p>

If any movement is made before the green screen, a "too early" message will pop up indicating that the move was made too soon, and the hand should return to the initial position again.

<p align="center">
  <img width="700" src="https://i.ibb.co/cJcmvQx/image.png">
</p>

After completing all the rounds you will be sent to the game over screen, and you will be able to see a graph of the same performance as in the game Box and Blocks.

## Full Article
https://repositorio.ifgoiano.edu.br/handle/prefix/2550

## License
 <footer>
      &copy; 2021 Lucas Keterson
  </footer>
