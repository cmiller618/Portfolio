import React, { useEffect, useState } from 'react';
import './App.css';

function App() {
  const [chessBoard, setChessBoard] = useState([]);

  useEffect(() => {
    fetchChessBoard();
  }, []);

  const fetchChessBoard = () => {
    // Make a request to your backend API to fetch the chessboard data
    // Replace 'your-api-endpoint' with the actual endpoint URL
    fetch('your-api-endpoint')
      .then((response) => response.json())
      .then((data) => setChessBoard(data))
      .catch((error) => console.log(error));
  };

  const isDarkSquare = (row, col) => {
    return (row + col) % 2 !== 0;
  };

  return (
    <div className="App">
      <div className="chessboard">
        {chessBoard.map((row, rowIndex) => (
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
    </div>
  );
}

export default App;
