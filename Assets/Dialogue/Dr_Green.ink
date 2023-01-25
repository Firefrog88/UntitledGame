INCLUDE GLOBALS.ink
Hello there! #speaker:bluey #portrait:bluey_neutral #layout:left

{ iceCream_flavor == "": -> main | -> already_chose }
VAR this_flavor = ""
=== main ===
Tell me your <color=\#F8FF30>favorite</color> Ice Cream flavor
+ [Definetly Chocolate...]
    ~ this_flavor = "Chocolate"
    I certainly appreciate a fellow <b>choc-lover!</b> #portrait:bluey_happy
+ [I'm team Strawberry]
    ~ this_flavor = "Strawberry"
    Sure... *sigh* I'll allow it
+ [Vanilla for me]
    ~ this_flavor = "Vanilla"
    Oh, wow... does that even count as a flavor?
+ [(Other flavor)]
    Hmm.. guess you are a little <color=\#FF1E35>reserved</color>, huh? #portrait:bluey_sad

- Oh leave them alone now, will ya? #speaker:greenard #portrait:greenard_angry #layout:right

Emm... do you maybe want to change your choice? #speaker:bluey #portrait:bluey_neutral #layout:left
+ [Sure]
    -> main
+ [No thanks]
    ...
    -> chosen(this_flavor)
    
=== chosen(flavor) ===
~ iceCream_flavor = flavor
    ->END
    
=== already_chose ===
You still thinking about {iceCream_flavor} I'm sure
    ->END