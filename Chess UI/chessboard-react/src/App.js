import React, { useEffect, useState } from 'react';
import './App.css';

function App() {
  const [board, setBoard] = useState([]);
  const [turn, setTurn] = useState(1);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchBoard();
  }, [turn]);

  const fetchBoard = () => {
    // Make a request to the backend API to fetch the board data
    fetch(`api/board/current-board?turn=${turn}`)
      .then((response) => {
        if (!response.ok) {
          console.log(response);
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then((data) => {
        setBoard(data);
        setLoading(false);
      })
      .catch((error) => {
        console.error('Error fetching board:', error);
        setLoading(false);
      });
  };

  const isDarkSquare = (row, col) => {
    return (row + col) % 2 !== 0;
  };

  const handleTurnChange = () => {
    // Update the turn variable to trigger a re-fetch of the board data
    setTurn(turn === 1 ? 2 : 1);
  };

  return (
    <div className="App">
      {loading ? (
        <div>Loading...</div>
      ) : (
        <div className="chessboard">
          {board.map((row, rowIndex) => (
            <div key={rowIndex} className="row">
              {row.map((piece, colIndex) => (
                <div
                  key={colIndex}
                  className={`square ${
                    isDarkSquare(rowIndex, colIndex) ? 'dark' : 'light'
                  }`}
                >
                  {piece && (
                    <img
                      src={piece.PieceFile} // Assuming PieceFile contains the image URL for the piece
                      alt={`Piece at ${colIndex},${rowIndex}`}
                    />
                  )}
                </div>
              ))}
            </div>
          ))}
        </div>
      )}

      <button onClick={handleTurnChange}>Change Turn</button>
    </div>
  );
}

export default App;
