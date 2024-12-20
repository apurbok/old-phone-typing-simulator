# Old Phone Typing Simulator #


### Desciption ###
In this project, we need to simulate the output of typing in a typical old button phone. Each button has a number/symbol to identify it and pressing a button
multiple times will cycle through the letters on it allowing each button to represent more than one letter (except *0#). According to the provided sample, the buttons have the following configuration:
* 1 => &'(
* 2 => abc
* 3 => def
* 4 => ghi
* 5 => jkl
* 6 => mno
* 7 => pqrs
* 8 => tuv
* 9 => wxyz
* \* => [Erase]
* 0 => [Space]
* \# => End of Input

For example, pressing 2 once will return ‘A’ but pressing twice in succession will return ‘B’. Pressing on '*' will remove the last returned character. Pressing on '#' will indicate the end of the input and it should be only at the end of the input string.

We can input strings of any length containing only the digits, symbols of the phone button, and space with a trailing '#'. Providing space in the input means that we are providing a time delay between pressing the buttons. This will be used to generate the output of multiple characters sequentially from a single button. Please refer to the test cases for better understanding.


### Test Cases ###
1. 227*# => B
2. 4433555 555666# => HELLO
3. 231242 22# => AD&AGAB
4. 998422222# => XTGB
5. 4533*5# => GJJ
6. 45***3 78 \*9 9\*4# => DPWG
7. 6059 999# => M JWY
8. 2000308# => A&nbsp;&nbsp;&nbsp;D T (Assuming the '0' button will always result in a space)
9. \# => (The output be an empty String)


### Required TechStack ###
* Visual Studio with .Net Sdk (preferred version 5+)


### How to use it? ###
* Clone the project and open the project directory by using the File Explorer locally
* Open the `.sln` file in Visual Studio
* Run the project and test your inputs


### Contact ###
* Apurba Karmaker (Owner of this repository)
* 1605096@ugrad.cse.buet.ac.bd
