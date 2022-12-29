# ProbabilitySelector
There is 2 ways you can use this class <br>
1)Accessing the static Select() method:<br>
ProbabilitySelector.Select(List<(object,float)> items)<br><br>

2)Creating an instance of ProbabilitySelector than executing whenever:<br>
ProbabilitySelector selector = new ProbabilitySelector();<br>
selector.Add(item,probability);<br>
selector.Execute();<br>

