using UnityEngine;

public class CaptureScreenshot : MonoBehaviour
{
    // Nome do arquivo para salvar a captura de tela
    public string screenshotFileName = "screenshot.png";

    void Update()
    {
        // Verifica se a tecla desejada foi pressionada (por exemplo, a tecla 'P')
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Captura a tela e salva a imagem com o nome especificado
            ScreenCapture.CaptureScreenshot(screenshotFileName);
            Debug.Log("Captura de tela salva como " + screenshotFileName);
        }
    }
}
