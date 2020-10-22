function validHorizontal(board)
{
  return board.every(l => l.reduce((a,e) => a + e) === 45);
}

function validVertical(board)
{
  for(let i=0;i<board.length;i++)
  {
    let acc = 0;
    for(let j=0;j<board[i].length;j++)
    {
      acc += board[j][i];
    }
    if(acc !== 45)
    {
      return false;
    }
  }
  return true;
}

function validSegments(board)
{
  let startXList = [0,3,6];
  let startYList = [0,3,6];
  for(let i=0;i<9;i++)
  {
  
    let acc = 0;
    startX = startXList[i % 3]
    startY = startYList[Math.floor(i / 3)]
    acc += board[startX][startY]
    acc += board[startX+1][startY]
    acc += board[startX+2][startY]
    acc += board[startX][startY+1]
    acc += board[startX+1][startY+1]
    acc += board[startX+2][startY+1]
    acc += board[startX][startY+2]
    acc += board[startX+1][startY+2]
    acc += board[startX+2][startY+2]
    
    if(acc !== 45)
    {
      return false;
    }
  }
  return true;
}

function validSolution(board){
  return validHorizontal(board) &&
    validVertical(board) &&
    validSegments(board);
}