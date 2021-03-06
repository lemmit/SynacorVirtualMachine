###My solution to The Synacor Challenge (challenge.synacor.com)  

I've implemented the virtual machine, but later got bored on the "gaming" part of the challenge.
Part of the game input that leads us towards the win is in game_input.txt file.  

THE CHALLENGE  
  
== Synacor Challenge ==  
In this challenge, your job is to use this architecture spec to create a
virtual machine capable of running the included binary.  Along the way,
you will find codes; submit these to the challenge website to track
your progress.  Good luck!  

  
== architecture ==  
- three storage regions  
  - memory with 15-bit address space storing 16-bit values  
  - eight registers  
  - an unbounded stack which holds individual 16-bit values  
- all numbers are unsigned integers 0..32767 (15-bit)  
- all math is modulo 32768; 32758 + 15 => 5  
  
== binary format ==  
- each number is stored as a 16-bit little-endian pair (low byte, high byte)  
- numbers 0..32767 mean a literal value  
- numbers 32768..32775 instead mean registers 0..7  
- numbers 32776..65535 are invalid  
- programs are loaded into memory starting at address 0  
- address 0 is the first 16-bit value, address 1 is the second 16-bit value, etc  
  
== execution ==  
- After an operation is executed, the next instruction to read is immediately after the last argument of the current operation.  If a jump was performed, the next operation is instead the exact destination of the jump.  
- Encountering a register as an operation argument should be taken as reading from the register or setting into the register as appropriate.  
  
== hints ==  
- Start with operations 0, 19, and 21.  
- Here's a code for the challenge website: VzueIPDhogKd  
- The program "9,32768,32769,4,19,32768" occupies six memory addresses and should:  
  - Store into register 0 the sum of 4 and the value contained in register 1.  
  - Output to the terminal the character with the ascii code contained in register 0.  

== opcode listing ==  
(full explanation on the challenge website)  
halt: 0  
set: 1 a b  
push: 2 a  
pop: 3 a  
eq: 4 a b c  
gt: 5 a b c  
jmp: 6 a  
jt: 7 a b  
jf: 8 a b  
add: 9 a b c  
mult: 10 a b c  
mod: 11 a b c  
and: 12 a b c  
or: 13 a b c  
not: 14 a b  
rmem: 15 a b  
wmem: 16 a b  
call: 17 a  
ret: 18  
out: 19 a  
in: 20 a  
noop: 21  