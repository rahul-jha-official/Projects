namespace DeckOfCardApp.Model;

public class Card
{
    public Suit suit { get; init; }
    public Face face { get; init; }

    public override string? ToString()
    {
        var val = (int)face;
        var myFace = val > 1 && val < 11 ? val.ToString() : face.ToString();
        return $"Card[Suit = {suit}, Face = {myFace}]";
    }
}
