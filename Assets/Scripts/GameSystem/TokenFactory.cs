using UnityEngine;

namespace GameSystem
{
    public static class TokenFactory
    {
        public static Token CreateToken(string color, GameObject tileGO) {
            // Creates GameObject
            var tokenGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            tokenGO.name = "Token (" + color + ")";
            tokenGO.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            tokenGO.transform.position = tileGO.transform.position + new Vector3(0, 0, -0.001f);
            tokenGO.GetComponent<Renderer>().material.color = color switch
            {
                "white" => Color.white,
                "black" => Color.black,
                "green" => Color.green,
                _ => tokenGO.GetComponent<Renderer>().material.color
            };

            // Creates MonoBehaviour
            tokenGO.AddComponent<Token>();
            var token = tokenGO.GetComponent<Token>();
            token.SetTokenGO(tokenGO);
            token.SetColor(tokenGO.GetComponent<Renderer>().material.color);
            token.SetTile(tileGO.GetComponent<Tile>());

            return token;
        }
    }
}

