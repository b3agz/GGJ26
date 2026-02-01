using UnityEngine;
using UnityEngine.UI;

namespace John {

    public class ItemButton : MonoBehaviour {

        [field: SerializeField] public Item Item { get; private set; }

        // The image to be displayed in the button.
        [SerializeField] private Image _buttonImage;

        // The actual item on the face.
        [SerializeField] private GameObject _faceItem;

        // So the image looks right in the button.
        [SerializeField] private AspectRatioFitter _aspectFitter;

        void Start() {

            if (Item == null) {
                Debug.LogError($"{transform.name} has an ItemButton script but no Item has been assigned.");
                Destroy(gameObject);
                return;
            }

            _buttonImage.sprite = Item.Image;
            _aspectFitter.aspectRatio = (float)_buttonImage.sprite.rect.width / _buttonImage.sprite.rect.height;

        }

        public void OnClick() {
            AddItem();
        }

        private void AddItem() {

            if (_faceItem != null) {
                Destroy(_faceItem);
                _faceItem = null;
                Judger.Instance.RemoveItem(Item);
                return;
            }

            GameObject newItem = new(Item.Name);
            newItem.transform.SetParent(GameManager.Instance.TheFace);
            SpriteRenderer sR = newItem.AddComponent<SpriteRenderer>();
            sR.sprite = Item.Image;
            newItem.transform.localPosition = Item.LocalPosition;
            newItem.transform.localScale = Item.LocalScale;

            _faceItem = newItem;
            Judger.Instance.AddItem(Item);

        }

    }

}
