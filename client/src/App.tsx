import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {

  //we define a type parameter for the activities
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
  axios.get<Activity[]>("https://localhost:5001/api/activities")
    .then(response => setActivities(response.data));
  }
  , []);

  return(
    <>
      <Typography variant = 'h3'>React website </Typography>
        
        <List>

          {activities.map(activity => (
            <ListItem key={activity.id}>
              <ListItemText>{activity.title}</ListItemText>
            </ListItem>
          ))}
        </List>

      
    </>
  
);
  
  
}

export default App
