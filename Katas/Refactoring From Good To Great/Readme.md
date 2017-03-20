C# version of [Aloha Ruby Conf 2012 Refactoring from Good to Great](https://www.youtube.com/watch?v=DC-pQPq0acs) talk by [Ben Orenstein](http://www.benorenstein.com/)


### Ordes Report

- A code smell indicates that there maybe is a problem
- Temp to query: Better reading. If you need additional knowledge go inside a method. Can reuse query later on: average sales implementation for instance. Temp to query and decent naming go together.
- Public API should be super clear, everything else is private
- Private means implementation details
- Tell don't ask : send a message to an object. order.placed_between? instead of asking order.palced_at and makind decisions based on that.
- Test: returns total sales within range
- Code smell: star/end dates should be grouped. Parameter object.
- Introduce date range with isBetween/includes?
- Parameter coupling. No coupling is bettern than 1 param. 1 param is better than 2 params..., etc.
- Date range - reduce coupling
