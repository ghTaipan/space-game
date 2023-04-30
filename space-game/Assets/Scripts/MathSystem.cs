using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MathSystem : UIParrent
{   [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;
    public int Duration;
    private int remainingDuration;
    private bool pause = false;

    private Animator MS;
    private int levelNumber;
    public TextMeshProUGUI question;
    public GameObject loadScene;
    public GameObject clickSound;
    public TMP_InputField inputField;
    private string givenInput;
    private int givenAnswer;
    private int a = -1;
    private int b = -1;
    private int ammoCount = 0;
    private int questionNumber = 1;
    private List<int> divisors = new List<int>();
    // Start is called before the first frame update
    private void Start()
    {
        MS = GetComponent<Animator>();
        MS.SetTrigger("MSOn");
        Question1();
        Invoke("WaitLoadScreen",1.5f);
        levelNumber = FindObjectOfType<DoNotDestory>().LevelNumber;
    }
    public void MainMenu(){
        buttonClicked = true;
        MS.SetTrigger("MStoMM");
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        Destroy(FindObjectOfType<DoNotDestory>().gameObject);
        Invoke("waitForMainMenu",1f);
    }
    private void waitForMainMenu(){
        SceneManager.LoadScene(0);
    }
    private void SetTimer(int Second){
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer(){
        while (remainingDuration >= 0){
            if(!pause){
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }
    private void OnEnd(){
        pause = true;
        remainingDuration = 60;
         MS.SetTrigger("T'sUP");
        if(questionNumber == 1){
                Invoke("Question2",3.5f);
                Invoke("ResetTimer",5f);
            }
            else if(questionNumber == 2){
                Invoke("Question3",3.5f);
                Invoke("ResetTimer",5f);
            }
            else if(questionNumber == 3){
                Invoke("Question4",3.5f);
                Invoke("ResetTimer",2.7f);
            }
            else{
                Invoke("StartGame",5f);
            }
            questionNumber++;
    }
    private void ResetTimer(){
        StartCoroutine(UpdateTimer());
    }
    private void ResetFillAndText(){
        uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
        uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
    }
    private void WaitLoadScreen(){
        SetTimer(Duration);
        loadScene.SetActive(false);
    }
    private void StartGame(){
        MS.SetTrigger("MSOff");
        Invoke("WaitForStartAnim",2f);
    }
    private void WaitForStartAnim(){
        FindObjectOfType<GameManager>().AmmoCount = ammoCount;
        FindObjectOfType<GameManager>().StartGame();
        gameObject.SetActive(false);
    }
    public void ReadStringInput(){
        givenInput = inputField.text;
        inputField.text = "";
        answer();
    }
    private void answer(){
        Instantiate(clickSound,soundPosition,Quaternion.identity);
        Invoke("destroySound",0.3f);
        if(int.TryParse(givenInput,out givenAnswer)){
            buttonClicked = true;
            pause = true;
            if(levelNumber / 4 == 0){
                if(a + b == givenAnswer){
                    if(questionNumber == 4){
                        MS.SetTrigger("CorFAns");
                        ammoCount++;
                    }
                    else{
                        MS.SetTrigger("CorAns");
                        ammoCount++;
                    }
                }
                else{
                    if(questionNumber == 4){
                         MS.SetTrigger("WrngFAns");
                    }
                    else{
                        MS.SetTrigger("WrngAns");
                    }
                }
            }
            else if(levelNumber / 4 == 1){
                if(a - b == givenAnswer){
                    if(questionNumber == 4){
                        MS.SetTrigger("CorFAns");
                        ammoCount++;
                    }
                    else{
                        MS.SetTrigger("CorAns");
                        ammoCount++;
                    }
                }
                else{
                    if(questionNumber == 4){
                         MS.SetTrigger("WrngFAns");
                    }
                    else{
                        MS.SetTrigger("WrngAns");
                    }
                }
            }
            else if(levelNumber / 4 == 2){
                if(a * b == givenAnswer){
                    if(questionNumber == 4){
                        MS.SetTrigger("CorFAns");
                        ammoCount++;
                    }
                    else{
                        MS.SetTrigger("CorAns");
                        ammoCount++;
                    }
                }
                else{
                    if(questionNumber == 4){
                         MS.SetTrigger("WrngFAns");
                    }
                    else{
                        MS.SetTrigger("WrngAns");
                    }
                }
            }
            else{
                if(a / b == givenAnswer){
                    if(questionNumber == 4){
                        MS.SetTrigger("CorFAns");
                        ammoCount++;
                    }
                    else{
                        MS.SetTrigger("CorAns");
                        ammoCount++;
                    }
                }
                else{
                    if(questionNumber == 4){
                         MS.SetTrigger("WrngFAns");
                    }
                    else{
                        MS.SetTrigger("WrngAns");
                    }
                }
            }
            if(questionNumber == 1){
                Invoke("Question2",3.5f);
            }
            else if(questionNumber == 2){
                Invoke("Question3",3.5f);
            }
            else if(questionNumber == 3){
                Invoke("Question4",3.5f);
            }
            else{
                Invoke("WaitForStartAnim",4.5f);
            }
            questionNumber++;
        }
        else{
            MS.SetTrigger("Warning");
        }
    }
    private void Question1(){ //For addition: 2 digit + 1 digit
        levelNumber = FindObjectOfType<DoNotDestory>().LevelNumber;
        if(levelNumber / 4 == 0){
            a = UnityEngine.Random.Range(10,100);
            b = UnityEngine.Random.Range(1,10);
            question.text = "What is the result of " + a.ToString() + " + " + b.ToString() + " = ?";
        }
        else if (levelNumber / 4 == 1){
            a = UnityEngine.Random.Range(10,100);
            b = UnityEngine.Random.Range(1,10);
            question.text = "What is the result of " + a.ToString() + " - " + b.ToString() + " = ?";
        }
        else if (levelNumber / 4 == 2){
            a = UnityEngine.Random.Range(10,100);
            b = UnityEngine.Random.Range(1,10);
            question.text = "What is the result of " + a.ToString() + " * " + b.ToString() + " = ?";
        }
        else{
            a = generateNPN(10,100);
            b = findRandomDivisor(a);
            question.text = "What is the result of " + a.ToString() + " / " + b.ToString() + " = ?";
        }
    }
    private void Question2(){ //For addition: 2 digit + 2 digit
        buttonClicked = false;
        remainingDuration = 60;
        ResetFillAndText();
        pause = false;
        if(levelNumber / 4 == 0){
            a = UnityEngine.Random.Range(10,100);
            b = UnityEngine.Random.Range(10,100);
            question.text = "What is the result of " + a.ToString() + " + " + b.ToString() + " = ?";
        }
        else if (levelNumber /4 == 1){
            a = UnityEngine.Random.Range(10,100);
            b = UnityEngine.Random.Range(10,a);
            question.text = "What is the result of " + a.ToString() + " - " + b.ToString() + " = ?";
        }
        else if (levelNumber /4 == 2){
            a = UnityEngine.Random.Range(10,100);
            b = UnityEngine.Random.Range(10,100);
            question.text = "What is the result of " + a.ToString() + " * " + b.ToString() + " = ?";
        }
        else{
            a = generateNPN(10,100);;
            divisors.Clear();
            b = findRandomDivisor(a);
            question.text = "What is the result of " + a.ToString() + " / " + b.ToString() + " = ?";
        }
    }
    private void Question3(){ //For addition: 3 digit + 2 digit
        buttonClicked = false;
        remainingDuration = 60;
        ResetFillAndText();
        pause = false;
        if(levelNumber / 4 == 0){
            a = UnityEngine.Random.Range(100,1000);
            b = UnityEngine.Random.Range(10,100);
            question.text = "What is the result of " + a.ToString() + " + " + b.ToString() + " = ?";
        }
        else if (levelNumber /4 == 1){
            a = UnityEngine.Random.Range(100,1000);
            b = UnityEngine.Random.Range(10,100);
            question.text = "What is the result of " + a.ToString() + " - " + b.ToString() + " = ?";
        }
        else if (levelNumber /4 == 2){
            a = UnityEngine.Random.Range(100,1000);
            b = UnityEngine.Random.Range(1,10);
            question.text = "What is the result of " + a.ToString() + " * " + b.ToString() + " = ?";
        }
        else{
            a = generateNPN(100,1000);;
            divisors.Clear();
            b = findRandomDivisor(a);
            question.text = "What is the result of " + a.ToString() + " / " + b.ToString() + " = ?";
        }
    }
    private void Question4(){ //For addition: 3 digit + 3 digit
        buttonClicked = false;
        remainingDuration = 60;
        ResetFillAndText();
        pause = false;
        if(levelNumber / 4 == 0){
            a = UnityEngine.Random.Range(100,1000);
            b = UnityEngine.Random.Range(100,1000);
            question.text = "What is the result of " + a.ToString() + " + " + b.ToString() + " = ?";
        }
        else if (levelNumber /4 == 1){
            a = UnityEngine.Random.Range(100,1000);
            b = UnityEngine.Random.Range(100,a);
            question.text = "What is the result of " + a.ToString() + " - " + b.ToString() + " = ?";
        }
        else if (levelNumber /4 == 2){
            a = UnityEngine.Random.Range(100,1000);
            b = UnityEngine.Random.Range(10,100);
            question.text = "What is the result of " + a.ToString() + " * " + b.ToString() + " = ?";
        }
        else{
            a = generateNPN(100,1000);
            divisors.Clear();
            b = findRandomDivisor(a);
            question.text = "What is the result of " + a.ToString() + " / " + b.ToString() + " = ?";
        }
    }
    private bool IsPrime(int num){
    if (num < 2) return false;
    for (int i = 2; i < num; i++)
    {
        if (num % i == 0)return false;
    }
    return true;
    }
    private int generateNPN(int R1, int R2){ // Generate a None Prime Number
        int num = Random.Range(R1, R2);
        while(IsPrime(num)){
            num = Random.Range(R1, R2);
        }
        return num;
    }
    private int findRandomDivisor(int num){
        for( int i = 2 ; i<= num ; i++){
            if( num % i == 0){
                divisors.Add(i);
            }
        }
        return divisors[Random.Range(0,divisors.Count-1)];
    }
}
