# ProbabilitySelector
There is 2 ways you can use this class <br>
1)Accessing the static Select() method:<br>
ProbabilitySelector.Select(List<(object,float)> items)<br><br>

2)Creating an instance of ProbabilitySelector than executing whenever:<br>
ProbabilitySelector selector = new ProbabilitySelector();<br>
selector.Add(item,probability);<br>
selector.Execute();<br>

Since the item is an object, you need to cast the return value. But the fact that the item is an object makes it possible for the items to be different.

