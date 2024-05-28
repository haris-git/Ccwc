# Ccwc
## Info
This is my own implementation of the word counter tool that exists in Unix systems. Given a text as an input parameter it will parse it and return soma info about this text. It is based on the guideline I found in this page [https://codingchallenges.fyi/challenges/challenge-wc].



## Examples (in terminal)
Displays help text.

```Ccwc --help```

Returns the the number of bytes in the input file.

```Ccwc -c ./Resources/test.txt```

Returns the the number of lines in the input file.

```Ccwc -l ./Resources/test.txt```

Returns the the number of words in the input file.

```Ccwc -w ./Resources/test.txt```

Returns the the number of characters in the input file.

```Ccwc -m ./Resources/test.txt```

When executing the program without any input parameters except from the filepath, it returns a reuslt which is the equivalent to the -c, -l and -w options.

```Ccwc ./Resources/test.txt```


## Todo
The program can't read from standard input yet, because I haven't implemented it.
