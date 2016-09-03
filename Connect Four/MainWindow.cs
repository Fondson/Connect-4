using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_Four
{
    public partial class frnGame : Form
    {
        #region initial variables
        private bool playerBlack = false;
        private bool playerBlackPlayAs = false;
        private bool aiState = true;
        private bool playerFirst = false;
        private bool blackFirst = true;
        private int choice;
        private int difficultyDepth = 7;
        #endregion

        public frnGame()
        {
            InitializeComponent();
            buttons[3].BackColor = Color.Black;
            colourState[3] = 2;
            buttons[3].Enabled = false;
            buttons[10].Enabled = true;
            colourState[10] = 3;

        }

        public void win(Color colour)
        {
            for (int i = 0; i < 42; i++)
            {
                buttons[i].Enabled = false;
            }
            lblPlayer.Text = colour + " WINS";
            lblPlayer.ForeColor = colour;
            MessageBox.Show(colour + " WINS");
        }

        #region Click listeners
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = ((Button)sender);
            button.Enabled = false;
            if (Int32.Parse(button.Name) < 36)
            {
                buttons[Int32.Parse(button.Name) + 6].Enabled = true;
                colourState[Int32.Parse(button.Name) + 6] = 3;
            }

            if (aiState)
            {
                //no longer used in favour of minimax algorithm
                #region simple ai
                //List<int> enabled = new List<int>();
                //button.BackColor = Color.Red;
                //if (checkWin(Int32.Parse(button.Name) - 1)) win(button.BackColor);
                //else
                //{
                //    bool canWin = false;
                //    bool blocked = false;
                //    for (int i = 0; i < 42; i++)
                //    {
                //        if (buttons[i].Enabled == true)
                //        {
                //            enabled.Add(i);
                //            buttons[i].BackColor = Color.Black;
                //            if (checkWin(Int32.Parse(buttons[i].Name) - 1))
                //            {
                //                buttons[i].BackColor = Color.Black;
                //                win(buttons[i].BackColor);
                //                canWin = true;
                //                break;
                //            }

                //            buttons[i].BackColor = Color.Red;
                //            if (checkWin(Int32.Parse(buttons[i].Name) - 1))
                //            {
                //                buttons[i].BackColor = Color.Black;
                //                buttons[i].Enabled = false;
                //                if (Int32.Parse(buttons[i].Name) < 36)
                //                {
                //                    buttons[Int32.Parse(buttons[i].Name) + 6].Enabled = true;
                //                }
                //                blocked = true;
                //                break;
                //            }
                //            buttons[i].BackColor = Color.White;
                //            buttons[i].UseVisualStyleBackColor = true;
                //        }
                //    }
                //    List<int> danger = new List<int>();
                //    if (!canWin && !blocked)
                //    {
                //        bool safe = false;
                //        Random rand = new Random();
                //        int i = 0;
                //        while (!safe && enabled.Count != 0)
                //        {
                //            int randNum = rand.Next(enabled.Count);

                //            i = enabled[randNum];
                //            if (Int32.Parse(buttons[i].Name) < 36)
                //            {
                //                buttons[i+7].BackColor = Color.Red;
                //                if (checkWin(Int32.Parse(buttons[i+7].Name) - 1))
                //                {
                //                    danger.Add(i);
                //                    enabled.Remove(i);
                //                    buttons[i + 7].BackColor = Color.White;
                //                    buttons[i + 7].UseVisualStyleBackColor = true;
                //                }
                //                else
                //                {
                //                    buttons[i].Enabled = false;
                //                    buttons[i].BackColor = Color.Black;
                //                    if (Int32.Parse(buttons[i].Name) < 36)
                //                    {
                //                        buttons[Int32.Parse(buttons[i].Name) + 6].Enabled = true;
                //                    }
                //                    safe = true;
                //                    buttons[i + 7].BackColor = Color.White;
                //                    buttons[i + 7].UseVisualStyleBackColor = true;
                //                    break;
                //                }
                //            }
                //            else
                //            {
                //                buttons[i].Enabled = false;
                //                buttons[i].BackColor = Color.Black;
                //                if (Int32.Parse(buttons[i].Name) < 36)
                //                {
                //                    buttons[Int32.Parse(buttons[i].Name) + 6].Enabled = true;
                //                }
                //                safe = true;
                //                break;
                //            }
                //        }
                //        if (!safe)
                //        {
                //            buttons[danger[0]].Enabled = false;
                //            buttons[danger[0]].BackColor = Color.Black;
                //            if (Int32.Parse(buttons[danger[0]].Name) < 36)
                //            {
                //                buttons[Int32.Parse(buttons[danger[0]].Name) + 6].Enabled = true;
                //            }
                //        }
                //    }
                //}
                #endregion           

                if (playerBlack)
                {
                    button.BackColor = Color.Black;
                    colourState[Int32.Parse(button.Name) - 1] = 2;
                    lblPlayer.Text = "Black's Turn";
                    lblPlayer.ForeColor = Color.Black;
                }
                else
                {
                    button.BackColor = Color.Red;
                    colourState[Int32.Parse(button.Name) - 1] = 1;
                    lblPlayer.Text = "Red's Turn";
                    lblPlayer.ForeColor = Color.Red;
                }

                if (checkWin(Int32.Parse(button.Name) - 1)) win(button.BackColor);
                else
                {

                    minimax(colourState[Int32.Parse(button.Name) - 1], Int32.Parse(button.Name) - 1, 0, Int32.MaxValue, Int32.MinValue);
                    if (!playerBlack)
                    {
                        buttons[choice].BackColor = Color.Black;
                        colourState[choice] = 2;
                    }
                    else
                    {
                        buttons[choice].BackColor = Color.Red;
                        colourState[choice] = 1;
                    }
                    if (!checkWin(choice))
                    {
                        buttons[choice].Enabled = false;
                        if (Int32.Parse(buttons[choice].Name) < 36)
                        {
                            buttons[Int32.Parse(buttons[choice].Name) + 6].Enabled = true;
                            colourState[Int32.Parse(buttons[choice].Name) + 6] = 3;
                        }
                    }
                    else
                    {
                        if (playerBlack) win(Color.Red);
                        else win(Color.Black);
                    }
                }
            }
            else
            {

                if (playerBlack)
                {
                    button.BackColor = Color.Black;
                    colourState[Int32.Parse(button.Name) - 1] = 2;
                    lblPlayer.Text = "Red's Turn";
                    lblPlayer.ForeColor = Color.Red;
                }
                else
                {
                    button.BackColor = Color.Red;
                    colourState[Int32.Parse(button.Name) - 1] = 1;
                    lblPlayer.Text = "Black's Turn";
                    lblPlayer.ForeColor = Color.Black;
                }
                playerBlack = !playerBlack;

                if (checkWin(Int32.Parse(button.Name) - 1)) win(button.BackColor);
            }
        }

        private void resetClick(object sender, EventArgs e)
        {
            playerBlack = playerBlackPlayAs;
            for (int i = 0; i < 42; i++)
            {
                buttons[i].BackColor = Color.White;
                colourState[i] = 0;
                buttons[i].UseVisualStyleBackColor = true;
                if (i < 7)
                {
                    buttons[i].Enabled = true;
                    colourState[i] = 3;
                }
                else
                {
                    buttons[i].Enabled = false;
                    colourState[i] = 0;
                }
            }
            if (aiState)
            {
                if (!playerFirst)
                {
                    if (!playerBlack)
                    {
                        buttons[3].BackColor = Color.Black;
                        colourState[3] = 2;
                    }
                    else
                    {
                        buttons[3].BackColor = Color.Red;
                        colourState[3] = 1;
                    }
                    buttons[3].Enabled = false;
                    buttons[10].Enabled = true;
                    colourState[10] = 3;
                }
            }

            if (!playerBlack)
            {
                lblPlayer.Text = "Red's Turn";
                lblPlayer.ForeColor = Color.Red;
            }
            else
            {
                lblPlayer.Text = "Black's Turn";
                lblPlayer.ForeColor = Color.Black;
            }
        }

        private void aiClick(object sender, EventArgs e)
        {
            aiState = !aiState;
            //btnAI.Text = aiState ? "AI: On" : "AI: Off";
            menuToggleAI.Checked = menuDifficulty.Enabled = aiState;
        }

        private void moveFirstClick(object sender, EventArgs e)
        {
            if (sender == menuFirstMoveRed)
            {
                blackFirst = false;

                playerFirst = !playerBlackPlayAs;

            }
            else
            {
                blackFirst = true;

                playerFirst = playerBlackPlayAs;
            }

            menuFirstMoveRed.Checked = !blackFirst;
            menuFirstMoveBlack.Checked = blackFirst;
            MessageBox.Show("Changes will take effect after reset.");
        }

        private void playAsClick(object sender, EventArgs e)
        {
            if (sender == menuPlayAsBlack)
            {
                playerBlackPlayAs = true;
                playerFirst = blackFirst;
            }
            else
            {
                playerBlackPlayAs = false;
                playerFirst = !blackFirst;
            }

            this.menuPlayAsBlack.Checked = playerBlackPlayAs;
            this.menuPlayAsRed.Checked = !playerBlackPlayAs;

            MessageBox.Show("Changes will take effect after reset.");
        }

        private void difficultyClick(object sender, EventArgs e)
        {
            difficultyDepth = Int32.Parse(((MenuItem)sender).Tag.ToString());
            for (int i = 0; i < menuDifficulty.MenuItems.Count; i++)
            {
                (menuDifficulty.MenuItems)[i].Checked = false;
            }
            ((MenuItem)sender).Checked = true;
        }

        #endregion

        #region Win Checkers   

        private bool checkWin(int position)
        {
            if (!checkWinHorizontal(position, 4, false))
                if (!checkWinVertical(position, 4, false))
                    if (!checkWinRightDiagonal(position, 4, false))
                        if (!checkWinLeftDiagonal(position, 4, false)) return false;
            return true;
        }

        private int checkWinCount(int position)
        {
            int count = 0;
            if (checkWinHorizontal(position, 4, false)) count += 1;
            if (checkWinVertical(position, 4, false)) count += 1;
            if (checkWinRightDiagonal(position, 4, false)) count += 1;
            if (checkWinLeftDiagonal(position, 4, false)) count += 1;
            return count;
        }

        private bool checkWinHorizontal(int position, int count, bool checkedRight)
        {
            if (count > 1)
            {
                bool canCheckRight = position % 7 != 0 ? true : false;
                if (canCheckRight && !checkedRight)
                {
                    if (colourState[position] == colourState[position - 1])
                    {
                        return checkWinHorizontal(position - 1, count - 1, checkedRight);
                    }
                }

                if (!checkedRight)
                {
                    count = 4;
                }
                checkedRight = true;

                bool canCheckLeft = (position + 1) % 7 != 0 ? true : false;
                if (canCheckLeft)
                {
                    if (colourState[position] == colourState[position + 1])
                    {
                        return checkWinHorizontal(position + 1, count - 1, checkedRight);
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkWinVertical(int position, int count, bool checkedAbove)
        {
            if (count > 1)
            {
                bool canCheckAbove = position + 7 < 42 ? true : false;
                if (canCheckAbove && !checkedAbove)
                {
                    if (colourState[position] == colourState[position + 7])
                    {
                        return checkWinVertical(position + 7, count - 1, checkedAbove);
                    }
                }

                if (!checkedAbove)
                {
                    count = 4;
                }
                checkedAbove = true;
                bool canCheckBelow = position - 7 > -1 ? true : false;
                if (canCheckBelow)
                {
                    if (colourState[position] == colourState[position - 7])
                    {
                        return checkWinVertical(position - 7, count - 1, checkedAbove);
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkWinRightDiagonal(int position, int count, bool checkedRightDiag)
        {
            if (count > 1)
            {
                bool canCheckUpRight = (position % 7 != 0) && (position + 6 < 42) ? true : false; ;
                if (canCheckUpRight && !checkedRightDiag)
                {
                    if (colourState[position] == colourState[position + 6])
                    {
                        return checkWinRightDiagonal(position + 6, count - 1, checkedRightDiag);
                    }
                }

                if (!checkedRightDiag)
                {
                    count = 4;
                }
                checkedRightDiag = true;

                bool canCheckDownLeft = ((position + 1) % 7 != 0) && (position - 6 > -1) ? true : false;
                if (canCheckDownLeft && checkedRightDiag)
                {
                    if (colourState[position] == colourState[position - 6])
                    {
                        return checkWinRightDiagonal(position - 6, count - 1, checkedRightDiag);
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkWinLeftDiagonal(int position, int count, bool checkedLeftDiag)
        {
            if (count > 1)
            {
                bool canCheckUpLeft = ((position + 1) % 7 != 0) && (position + 8 < 42) ? true : false; ;
                if (canCheckUpLeft && !checkedLeftDiag)
                {
                    if (colourState[position] == colourState[position + 8])
                    {
                        return checkWinLeftDiagonal(position + 8, count - 1, checkedLeftDiag);
                    }
                }

                if (!checkedLeftDiag)
                {
                    count = 4;
                }
                checkedLeftDiag = true;

                bool canCheckDownRight = (position % 7 != 0) && (position - 8 > -1) ? true : false;
                if (canCheckDownRight && checkedLeftDiag)
                {
                    if (colourState[position] == colourState[position - 8])
                    {
                        return checkWinLeftDiagonal(position - 8, count - 1, checkedLeftDiag);
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region miniimax
        private int minimax(int colour, int position, int depth, int upper, int lower)
        {
            if (checkWin(position))
            {
                return winScore(colour, depth);
            }
            depth += 1;
            if (depth < difficultyDepth)
            {
                colour = colour == 2 ? 1 : 2;
                List<int> scores = new List<int>();
                List<int> moves = new List<int>();

                if ((!playerBlack && colour == 1) || (playerBlack && colour == 2))
                {
                    int tester;
                    upper = int.MaxValue;
                    for (int i = 0; i < 42; i++)
                    {
                        if (colourState[i] == 3)
                        {
                            colourState[i] = colour;
                            if (i < 35)
                            {
                                colourState[i + 7] = 3;
                            }
                            tester = minimax(colour, i, depth, upper, lower);
                            moves.Add(i);
                            upper = min(upper, tester);
                            if (i < 35)
                            {
                                colourState[i + 7] = 0;
                            }
                            colourState[i] = 3;
                            if (lower >= upper)
                            {
                                scores.Add(upper);
                                break;
                            }
                            else
                            {
                                scores.Add(tester);
                            }
                        }

                    }
                }
                else
                {
                    int tester;
                    lower = int.MinValue;
                    for (int i = 0; i < 42; i++)
                    {
                        if (colourState[i] == 3)
                        {
                            colourState[i] = colour;
                            if (i < 35)
                            {
                                colourState[i + 7] = 3;
                            }
                            tester = minimax(colour, i, depth, upper, lower);
                            moves.Add(i);
                            lower = max(lower, tester);
                            if (i < 35)
                            {
                                colourState[i + 7] = 0;
                            }
                            colourState[i] = 3;
                            if (lower >= upper)
                            {
                                scores.Add(lower);
                                break;
                            }
                            else
                            {
                                scores.Add(tester);
                            }
                        }

                    }

                }
                if (scores.Count == 1)
                {
                    choice = moves[0];
                    return scores[0];
                }
                else if (scores.Count > 1)
                {
                    int startingIndex = 0;
                    if ((!playerBlack && colour == 1) || (playerBlack && colour == 2))
                    {
                        int minScore;
                        minScore = scores[startingIndex];
                        int minIndex = startingIndex;
                        for (int i = 0; i < scores.Count; i++)
                        {
                            if (scores[i] < minScore)
                            {
                                minScore = scores[i];
                                minIndex = i;
                            }
                        }
                        if (depth == 1)
                        {//for debugging purposes
                        }

                        choice = moves[minIndex];
                        return minScore;
                    }
                    else
                    {
                        int maxScore;
                        maxScore = scores[startingIndex];
                        int maxIndex = startingIndex;
                        for (int i = 0; i < scores.Count; i++)
                        {
                            if (scores[i] > maxScore)
                            {
                                maxScore = scores[i];
                                maxIndex = i;
                            }
                        }
                        choice = moves[maxIndex];

                        if (depth == 1)
                        {//for debugging purposes
                        }

                        return maxScore;
                    }
                }
            }
            return maxDepthScore(colour, position, depth);
        }

        #endregion

        #region Score evaluators

        private int winScore(int colour, int depth)
        {
            if ((!playerBlack && colour == 1) || (playerBlack && colour == 2))
            {
                return (depth * 400) - int.MaxValue;
            }
            else
            {
                return int.MaxValue - (depth * 400);
            }
        }

        private int maxDepthScore(int colour, int position, int depth)
        {
            if ((!playerBlack && colour == 1) && (playerBlack && colour == 2))
                if (playerBlack)
                    return -checkForThreats(2, 2) + checkForThreats(2, 1) - depth + evaluateContent(colour);
                else
                    return -checkForThreats(2, 1) + checkForThreats(2, 2) - depth + evaluateContent(colour);
            else                                                            
            {
                if (playerBlack)
                    return checkForThreats(2, 1) - checkForThreats(2, 2) + depth + evaluateContent(colour);
                else
                    return checkForThreats(2, 2) - checkForThreats(2, 1) + depth + evaluateContent(colour);
            }                                                                         
        }

        #endregion

        #region Gaussian utility
        ////original table of values
        //private static int[,] evaluationTable = new int[,]{ { 3, 4, 5, 7, 5, 4, 3 },
        //                                                    { 4, 6, 8, 10, 8, 6, 4 },
        //                                                    { 5, 8, 11, 13, 11, 8, 5 },
        //                                                    { 5, 8, 11, 13, 11, 8, 5 },
        //                                                    { 4, 6, 8, 10, 8, 6, 4 },
        //                                                    { 3, 4, 5, 7, 5, 4, 3 } };


        private int[] evaluationValues = new int[] {3, 4, 5, 7, 5, 4, 3,
                                                    4, 6, 8, 10, 8, 6, 4,
                                                    5, 8, 11, 13, 11, 8, 5,
                                                    5, 8, 11, 13, 11, 8, 5,
                                                    4, 6, 8, 10, 8, 6, 4,
                                                    3, 4, 5, 7, 5, 4, 3};

        //here is where the evaluation table is called 
        public int evaluateContent(int colour)
        {
            int sum = 0;
            for (int i = 0; i < 42; i++)
            {
                if (colourState[i] == colour)
                {
                    if (((!playerBlack && colour == 1)) || ((playerBlack && colour == 2)))
                    {
                        sum -= evaluationValues[i];
                    }
                    else
                        sum += evaluationValues[i];
                }
                else if (colourState[i] == 1 || colourState[i] == 2)
                {
                    if (((!playerBlack && colour == 1)) || ((playerBlack && colour == 2)))
                    {
                        sum += evaluationValues[i];
                    }
                    else
                        sum -= evaluationValues[i];
                }
            }
            return sum;
        }
        #endregion

        #region Threat calculation

        private int checkForThreats(int depth, int colourToCheck)
        {
            if (depth == 0)
            {
                return 0;
            }
            else
            {
                int results = 0;
                for (int i = 0; i < 42; i++)
                {
                    if (colourState[i] == 3)
                    {
                        colourState[i] = colourToCheck;
                        if (i < 35)
                        {
                            colourState[i + 7] = 3;
                        }
                        results += checkForThreats(depth - 1, colourToCheck);
                        int count = checkWinCount(i);
                        results += (count * 70) / ((i + 7) / 7) / depth;
                        if (i < 35)
                        {
                            colourState[i + 7] = 0;
                        }
                        colourState[i] = 3;
                    }
                }
                return results;
            }
        }

        #endregion

        #region helper methods
        private int min(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else if (a > b)
            {
                return b;
            }
            return a;
        }
        private int max(int a, int b)
        {
            if (a < b)
            {
                return b;
            }
            else if (a > b)
            {
                return a;
            }
            return a;
        }
        #endregion
    }
}