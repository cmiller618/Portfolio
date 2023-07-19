import React, { useEffect, useState } from 'react';
import './App.css';

function App() {
  const [board, setBoard] = useState([]);
  const [turn, setTurn] = useState(1);

  useEffect(() => {
    fetchBoard();
  }, [turn]);

  const fetchBoard = () => {
    // Make a request to the backend API to fetch the board data
    fetch(`${process.env.REACT_APP_BACKEND_URL}/api/board/current-board?turn=${turn}`)
      .then((onJson))
      .then((data) => setBoard(data))
      .catch((error) => console.log(error));
  };

  const onJson = (x) => {
    const header = {'Content-Type':'application/json',
                    'Access-Control-Allow-Origin':'*',
                    'Access-Control-Allow-Methods':"OPTIONS,POST,GET"}
    const response = {
      statusCode: 200,
      headers: header,
      body: JSON.stringify(x),
    };
    return response;
  }

  const isDarkSquare = (row, col) => {
    return (row + col) % 2 !== 0;
  };

  const handleTurnChange = () => {
    // Update the turn variable to trigger a re-fetch of the board data
    setTurn(turn === 1 ? 2 : 1);
  };

  return (
    <div className="App">
      <div className="chessboard">
        {board.map((row, rowIndex) => (
          <div key={rowIndex} className="row">
            {row.map((piece, colIndex) => (
              <div
                key={colIndex}
                className={`square ${isDarkSquare(rowIndex, colIndex) ? 'dark' : 'light'}`}
              >
                {piece && (
                  <img
                    src={piece.PieceFile}
                    alt={`Piece at ${colIndex},${rowIndex}`}
                  />
                )}
              </div>
            ))}
          </div>
        ))}
      </div>

      <button onClick={handleTurnChange}>Change Turn</button>
    </div>
  );
}

export default App;
