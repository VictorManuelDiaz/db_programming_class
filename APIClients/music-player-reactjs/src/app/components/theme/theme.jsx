import React from 'react';
import ThemeView from './theme.view';

const Theme = (props) => {
    const [open, setOpen] = React.useState(false);
    const [openList, setOpenList] = React.useState(false);

  const handleClick = () => {
    setOpenList(!openList);
  };

    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    return (
        <ThemeView
            children={props.children}
            openList={openList}
            open={open}
            handleClick={handleClick}
            handleDrawerOpen={handleDrawerOpen}
            handleDrawerClose={handleDrawerClose}
        />
    )
}

export default Theme;