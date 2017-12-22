namespace FLexer.Tests

open NUnit.Framework
open FLexer.Core.Descent

[<DescentTests>]
type DescentTests () =

    let basicStatus =
        {   CurrentChar = 0
            Remainder = "SELECT * FROM TESTS;"
        }

    [<SetUp>]
    member __.Setup () =
        ()

    [<Test>]
    member __.``TakeChar - Assure that one char is consumed`` () =
        match TakeChar 'S' basicStatus with 
        | Ok(text, status) ->
            Assert.AreEqual("S", text)
            Assert.AreEqual(1, status.CurrentChar)
            Assert.AreEqual("ELECT * FROM TESTS;", status.Remainder)
        | Error _ ->
            Assert.Fail("Should consume one 'S' character.")

    [<Test>]
    member __.``TakeChar - Assure that one char is NOT consumed`` () =
        match TakeChar 'M' basicStatus with 
        | Ok(_) ->
            Assert.Fail("Should NOT consume character.")
        | Error _ ->
            ()
            
    [<Test>]
    member __.``TakeCharRange - Assure that one char is consumed`` () =
        match TakeCharRange 'R' 'Y' basicStatus with 
        | Ok(text, status) ->
            Assert.AreEqual("S", text)
            Assert.AreEqual(1, status.CurrentChar)
            Assert.AreEqual("ELECT * FROM TESTS;", status.Remainder)
        | Error _ ->
            Assert.Fail("Should consume one 'S' character.")

    [<Test>]
    member __.``TakeCharRange - Assure that one char is NOT consumed`` () =
        match TakeCharRange 'M' 'P' basicStatus with 
        | Ok(_) ->
            Assert.Fail("Should NOT consume character.")
        | Error _ ->
            ()