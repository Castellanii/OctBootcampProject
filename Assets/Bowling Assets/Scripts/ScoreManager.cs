using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;


    private int totalScore;
    private int[] frames = new int[10];
    private bool isSpare = false;
    private bool isStrike = false;

    public int currentThrow { get; private set; }
    public int currentFrame { get; private set; }


    //Set value for our frame score each time we throw the ball
    public void SetFrameScore(int score)
    {
        //Ball1
        if (currentThrow == 1)
        {
            frames[currentThrow - 1] += score;

            //Parallel process to check spare
            if (isSpare)
            {
                frames[currentThrow - 2] += score;
                isSpare = false;
            }
            //------------------------------------------
            if (score == 10)
            {
                if (currentFrame == 10)
                {
                    currentThrow++; //Wait for Ball2
                }
                else
                {
                    isStrike = true;
                    currentFrame++; //Move to next frame since max points

                }
                gameManager.ResetAllPins();
            }


            else
            {
                currentThrow++; //Wait for ball 2
            }
            return;



        }

        //Ball 2
        if (currentThrow == 2)
        {
            frames[currentFrame] += score;

            //prarallel process to check strike 
            if (isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;

            }
            //--------------------------------------------------
            if (frames[currentFrame - 1] == 10) //is total frame score 10?
            {
                if (currentFrame == 10)
                {
                    currentThrow++; //Wait for ball 3
                }
                else
                {
                    isSpare = true;
                    currentFrame++;
                    currentThrow = 1;
                }
            }
            else
            {
                if (currentFrame == 10)
                {
                    //End all throws
                    currentThrow = 0;
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1;
                }
            }

            //TODO GameManager to Reset all pins
            gameManager.ResetAllPins();

            return;

        }

        //Ball 3 only frame 10
        if (currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;

            //End of all throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }

    }

    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach (var frame in frames)
        {
            totalScore += frame;
        }
        return totalScore;

    }

    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];
    }


    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
